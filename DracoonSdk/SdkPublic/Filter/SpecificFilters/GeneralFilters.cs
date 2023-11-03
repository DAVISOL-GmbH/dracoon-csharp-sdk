using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.Validator;
using System;
using System.Globalization;

namespace Dracoon.Sdk.Filter {

    #region Base Types

    [Flags]
    public enum FilterOperator : int {
        None = 0,

        Equals = 1 << 0,
        Contains = 1 << 1,
        StartsWith = 1 << 2,
        GreaterThanOrEqual = 1 << 8,
        LessThanOrEqual = 1 << 10
    }

    public interface IFilter {
        FilterOperator DefaultOperators { get; }

        FilterOperator FilterOperators { get; }
    }

    public abstract class FilterBase<TFilter> : DracoonFilterType<TFilter>, IFilter where TFilter : IFilter {
        internal FilterBase(string filterName) {
            FilterTypeString += filterName;
            FilterOperators = DefaultOperators;
        }
        internal FilterBase(string filterName, FilterOperator filterOperators) {
            FilterTypeString += filterName;
            FilterOperators = filterOperators;
        }

        public abstract FilterOperator DefaultOperators { get; }

        public FilterOperator FilterOperators { get; private set; }
    }

    public abstract class IdFilterBase<TFilter> : FilterBase<TFilter> where TFilter : IFilter {
        internal IdFilterBase(string filterName)
            : base(filterName) { }
        internal IdFilterBase(string filterName, FilterOperator filterOperators)
            : base(filterName, filterOperators) { }

        public override FilterOperator DefaultOperators => FilterOperator.Equals;
    }

    public abstract class TextFilterBase<TFilter> : FilterBase<TFilter> where TFilter : IFilter {
        internal TextFilterBase(string filterName)
            : base(filterName) { }
        internal TextFilterBase(string filterName, FilterOperator filterOperators)
            : base(filterName, filterOperators) { }

        public override FilterOperator DefaultOperators => FilterOperator.Equals | FilterOperator.Contains;
    }

    public abstract class BoolFilterBase<TFilter> : FilterBase<TFilter> where TFilter : IFilter {
        internal BoolFilterBase(string filterName)
            : base(filterName) { }
        internal BoolFilterBase(string filterName, bool anyAllowed)
            : base(filterName) {
            AnyAllowed = anyAllowed;
        }

        public bool AnyAllowed { get; private set; }

        public override FilterOperator DefaultOperators => FilterOperator.Equals;
    }

    public abstract class DateFilterBase<TFilter> : FilterBase<TFilter> where TFilter : IFilter {
        internal DateFilterBase(string filterName)
            : base(filterName) { }
        internal DateFilterBase(string filterName, FilterOperator filterOperators)
            : base(filterName, filterOperators) { }

        public override FilterOperator DefaultOperators => FilterOperator.LessThanOrEqual | FilterOperator.GreaterThanOrEqual;
    }

    public static class CommonFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<TFilter, DracoonFilterType<TFilter>> EqualsId<TFilter>(this TFilter ef, long value) where TFilter : IdFilterBase<TFilter> {
            if (!ef.FilterOperators.HasFlag(FilterOperator.Equals))
                throw new NotSupportedException("This filter operator is not supported in this scope!");
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<TFilter, DracoonFilterType<TFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<TFilter, DracoonFilterType<TFilter>> EqualsFlag<TFilter>(this TFilter ef, bool value) where TFilter : BoolFilterBase<TFilter> {
            if (!ef.FilterOperators.HasFlag(FilterOperator.Equals))
                throw new NotSupportedException("This filter operator is not supported in this scope!");
            ef.AddOperatorAndValue(BoolToString(value), "eq", nameof(value));
            return new FilterParam<TFilter, DracoonFilterType<TFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<TFilter, DracoonFilterType<TFilter>> EqualsFlag<TFilter>(this TFilter ef, bool? value) where TFilter : BoolFilterBase<TFilter> {
            if (!ef.FilterOperators.HasFlag(FilterOperator.Equals))
                throw new NotSupportedException("This filter operator is not supported in this scope!");
            if (!ef.AnyAllowed)
                value.MustHaveValue(nameof(value));
            ef.AddOperatorAndValue(BoolToString(value), "eq", nameof(value));
            return new FilterParam<TFilter, DracoonFilterType<TFilter>>(ef, ef);
        }

        private static string BoolToString(bool? value) {
            if (!value.HasValue)
                return "any";

            return value.Value ? "true" : "false";
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<TFilter, DracoonFilterType<TFilter>> EqualsText<TFilter>(this TFilter ef, string value) where TFilter : TextFilterBase<TFilter> {
            if (!ef.FilterOperators.HasFlag(FilterOperator.Contains))
                throw new NotSupportedException("This filter operator is not supported in this scope!");
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<TFilter, DracoonFilterType<TFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<TFilter, DracoonFilterType<TFilter>> ContainsText<TFilter>(this TFilter ef, string value) where TFilter : TextFilterBase<TFilter> {
            if (!ef.FilterOperators.HasFlag(FilterOperator.Contains))
                throw new NotSupportedException("This filter operator is not supported in this scope!");
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<TFilter, DracoonFilterType<TFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<TFilter, DracoonFilterType<TFilter>> StartsWithText<TFilter>(this TFilter ef, string value) where TFilter : TextFilterBase<TFilter> {
            if (!ef.FilterOperators.HasFlag(FilterOperator.StartsWith))
                throw new NotSupportedException("This filter operator is not supported in this scope!");
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "sw", nameof(value));
            return new FilterParam<TFilter, DracoonFilterType<TFilter>>(ef, ef);
        }
    }


    public static class DateFilterExtension {
        public static FilterParam<DateFilterBase<TFilter>, DateFilterBase<TFilter>> GreaterThanOrEqual<TFilter>(this DateFilterBase<TFilter> ef, DateTime date) where TFilter : IFilter {
            date.MustNotBeDefault(nameof(date));
            ef.AddOperatorAndValue(date.ToString("yyyy-MM-dd"), "ge", nameof(date));
            return new FilterParam<DateFilterBase<TFilter>, DateFilterBase<TFilter>>(ef, ef);
        }
        public static FilterParam<DateFilterBase<TFilter>, DateFilterBase<TFilter>> LessThanOrEqual<TFilter>(this DateFilterBase<TFilter> ef, DateTime date) where TFilter : IFilter {
            date.MustNotBeDefault(nameof(date));
            ef.AddOperatorAndValue(date.ToString("yyyy-MM-dd"), "le", nameof(date));
            return new FilterParam<DateFilterBase<TFilter>, DateFilterBase<TFilter>>(ef, ef);
        }
    }

    #endregion

    #region NodeType-Filter

    /// <summary>
    ///     Filter for the field 'Type' of a node. See also <seealso cref="Dracoon.Sdk.Model.Node"/>
    /// </summary>
    public class NodeTypeFilter : DracoonFilterType<NodeTypeFilter> {
        internal NodeTypeFilter() {
            FilterName = "type";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.NodeTypeFilter"/>.
    /// </summary>
    public static class NodeTypeFilterExtension {
        /// <summary>
        ///     Adds the possibility to define another value for the given filter which should be fulfilled.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <returns>The class for which the extension is provided.</returns>
        public static NodeTypeFilter Or(this FilterParam<NodeTypeFilter, DracoonFilterType<NodeTypeFilter>> ef) {
            return ef.Parent;
        }

        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<NodeTypeFilter, DracoonFilterType<NodeTypeFilter>> EqualTo(this NodeTypeFilter ef, NodeType value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<NodeTypeFilter, DracoonFilterType<NodeTypeFilter>>(ef, ef);
        }
    }

    #endregion

    #region IsFavorite-Filter

    /// <summary>
    ///     Filter for the field 'IsFavorite' of a node. See also <seealso cref="Dracoon.Sdk.Model.Node"/>
    /// </summary>
    public class IsFavoriteFilter : DracoonFilterType<IsFavoriteFilter> {
        internal IsFavoriteFilter() {
            FilterName = "isFavorite";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.IsFavoriteFilter"/>.
    /// </summary>
    public static class NodeIsFavoriteFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<IsFavoriteFilter, DracoonFilterType<IsFavoriteFilter>> EqualTo(this IsFavoriteFilter ef, bool value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<IsFavoriteFilter, DracoonFilterType<IsFavoriteFilter>>(ef, ef);
        }
    }

    #endregion

    #region Name-Filter

    /// <summary>
    ///     Filter for the field 'Name' of a node. See also <seealso cref="Dracoon.Sdk.Model.Node"/>
    /// </summary>
    public class NameFilter : TextFilterBase<NameFilter> {
        internal NameFilter() : base("name") {
        }
        internal NameFilter(string filterName) : base(filterName) {
        }
        internal NameFilter(string filterName, FilterOperator filterOperators) : base(filterName, filterOperators) {
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.NameFilter"/>.
    /// </summary>
    public static class NodeNameFilterExtension {
        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<NameFilter, DracoonFilterType<NameFilter>> Contains(this NameFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<NameFilter, DracoonFilterType<NameFilter>>(ef, ef);
        }
    }

    #endregion

    #region IsEncrypted-Filter

    /// <summary>
    ///     Filter for the field 'IsEncrypted' of a node. See also <seealso cref="Dracoon.Sdk.Model.Node"/>
    /// </summary>
    public class NodeIsEncryptedFilter : DracoonFilterType<NodeIsEncryptedFilter> {
        internal NodeIsEncryptedFilter() {
            FilterName = "encrypted";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.NodeIsEncryptedFilter"/>.
    /// </summary>
    public static class NodeIsEncryptedFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<NodeIsEncryptedFilter, DracoonFilterType<NodeIsEncryptedFilter>> EqualTo(this NodeIsEncryptedFilter ef, bool value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<NodeIsEncryptedFilter, DracoonFilterType<NodeIsEncryptedFilter>>(ef, ef);
        }
    }

    #endregion

    #region UserId-Filter

    /// <summary>
    ///     Filter for a specific user.
    /// </summary>
    public class UserIdFilter : IdFilterBase<UserIdFilter> {
        internal UserIdFilter() : base("userId") {
        }
        internal UserIdFilter(string filterName) : base(filterName) {
        }

        internal UserIdFilter(string filterName, FilterOperator filterOperators) : base(filterName, filterOperators) {
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.UserIdFilter"/>.
    /// </summary>
    public static class UserIdFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<UserIdFilter, DracoonFilterType<UserIdFilter>> EqualTo(this UserIdFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<UserIdFilter, DracoonFilterType<UserIdFilter>>(ef, ef);
        }
    }

    #endregion

    #region UpdatedBy-Filter

    /// <summary>
    ///     Filter for a specific user which updated a e.g. node.
    /// </summary>
    public class UpdatedByFilter : DracoonFilterType<UpdatedByFilter> {
        internal UpdatedByFilter() {
            FilterName = "updatedBy";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.UpdatedByFilter"/>.
    /// </summary>
    public static class UpdatedByFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>> EqualTo(this UpdatedByFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>>(ef, ef);
        }

        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>> Contains(this UpdatedByFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>>(ef, ef);
        }
    }

    #region UpdatedAt-Filter

    public class UpdatedAtFilter : DateFilterBase<UpdatedAtFilter> {
        internal UpdatedAtFilter() : base("updatedAt") {
        }
    }

    #endregion

    #endregion

    #region UpdatedById-Filter

    /// <summary>
    ///     Filter for a specific user id which updated a e.g. node.
    /// </summary>
    public class UpdatedByIdFilter : DracoonFilterType<UpdatedByIdFilter> {
        internal UpdatedByIdFilter() {
            FilterName = "updatedById";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.UpdatedByIdFilter"/>.
    /// </summary>
    public static class UpdatedByIdFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<UpdatedByIdFilter, DracoonFilterType<UpdatedByIdFilter>> EqualTo(this UpdatedByIdFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<UpdatedByIdFilter, DracoonFilterType<UpdatedByIdFilter>>(ef, ef);
        }
    }

    #endregion

    #region ParentPath-Filter

    /// <summary>
    ///     Filter to get only results where the parent path field matches the requested.
    /// </summary>
    public class ParentPathFilter : DracoonFilterType<ParentPathFilter> {
        internal ParentPathFilter() {
            FilterName = "parentPath";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.ParentPathFilter"/>.
    /// </summary>
    public static class ParentPathFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>> EqualTo(this ParentPathFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>>(ef, ef);
        }

        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>> Contains(this ParentPathFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>>(ef, ef);
        }
    }

    #endregion

    #region FileType-Filter

    /// <summary>
    ///     Filter to get only results where the file type has the specified extension. E.g. 'ico', 'txt', ...
    /// </summary>
    public class FileTypeFilter : DracoonFilterType<FileTypeFilter> {
        internal FileTypeFilter() {
            FilterName = "fileType";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.FileTypeFilter"/>.
    /// </summary>
    public static class FileTypeFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>> EqualTo(this FileTypeFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>>(ef, ef);
        }

        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>> Contains(this FileTypeFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>>(ef, ef);
        }
    }

    #endregion

    #region BranchVersion-Filter

    public class BranchVersionFilter : DracoonFilterType<BranchVersionFilter> {
        internal BranchVersionFilter() {
            FilterTypeString += "branchVersion";
        }
    }

    public static class BranchVersionFilterExtension {
        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/GreaterThanOrEqual/*'/>
        public static FilterParam<BranchVersionFilter, DracoonFilterType<BranchVersionFilter>> GreaterThanOrEqual(this BranchVersionFilter ef,
            long value) {
            ef.AddOperatorAndValue((int)value, "ge", nameof(value));
            return new FilterParam<BranchVersionFilter, DracoonFilterType<BranchVersionFilter>>(ef, ef);
        }
        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/LessThanOrEqual/*'/>
        public static FilterParam<BranchVersionFilter, DracoonFilterType<BranchVersionFilter>> LessThanOrEqual(this BranchVersionFilter ef,
            long value) {
            ef.AddOperatorAndValue((int)value, "le", nameof(value));
            return new FilterParam<BranchVersionFilter, DracoonFilterType<BranchVersionFilter>>(ef, ef);
        }
    }

    #endregion

    #region Classification-Filter

    /// <summary>
    ///     Filter to get only results where the classification is of the specified type.
    /// </summary>
    public class ClassificationFilter : DracoonFilterType<ClassificationFilter> {
        internal ClassificationFilter() {
            FilterName = "classification";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.ClassificationFilter"/>.
    /// </summary>
    public static class ClassificationFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<ClassificationFilter, DracoonFilterType<ClassificationFilter>> EqualTo(this ClassificationFilter ef,
            Classification value) {
            ef.AddOperatorAndValue((int)value, "eq", nameof(value));
            return new FilterParam<ClassificationFilter, DracoonFilterType<ClassificationFilter>>(ef, ef);
        }
    }

    #endregion

    #region CreatedBy-Filter

    /// <summary>
    ///     Filter to get only results where the creator (firstname, lastname, login) contains the specified value.
    /// </summary>
    public class CreatedByFilter : DracoonFilterType<CreatedByFilter> {
        internal CreatedByFilter() {
            FilterName = "createdBy";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.CreatedByFilter"/>.
    /// </summary>
    public static class CreatedByFilterExtension {
        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<CreatedByFilter, DracoonFilterType<CreatedByFilter>> Contains(this CreatedByFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<CreatedByFilter, DracoonFilterType<CreatedByFilter>>(ef, ef);
        }
    }

    #endregion

    #region CreatedAt-Filter

    public class CreatedAtFilter : DateFilterBase<CreatedAtFilter> {
        internal CreatedAtFilter() : base("createdAt") {
        }
    }

    #endregion

    #region ExpireAt-Filter

    public class ExpireAtFilter : DateFilterBase<ExpireAtFilter> {
        internal ExpireAtFilter() : base("expireAt") {
        }
    }

    #endregion

    #region CreatedById-Filter

    /// <summary>
    ///     Filter to get only results where the creator id equals the specified value.
    /// </summary>
    public class CreatedByIdFilter : DracoonFilterType<CreatedByIdFilter> {
        internal CreatedByIdFilter() {
            FilterName = "createdById";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.CreatedByIdFilter"/>.
    /// </summary>
    public static class CreatedByIdFilterExtension {
        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<CreatedByIdFilter, DracoonFilterType<CreatedByIdFilter>> EqualTo(this CreatedByIdFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<CreatedByIdFilter, DracoonFilterType<CreatedByIdFilter>>(ef, ef);
        }
    }

    #endregion

    #region NodeId_TargetId-Filter

    /// <summary>
    ///     Filter to get only results where the referenced node is the specified id.
    /// </summary>
    public class NodeIdFilter : IdFilterBase<NodeIdFilter> {
        internal NodeIdFilter() : base("nodeId") {
        }
        internal NodeIdFilter(string filterName) : base(filterName) {
        }
        internal NodeIdFilter(string filterName, FilterOperator filterOperators) : base(filterName, filterOperators) {
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.NodeIdFilter"/>.
    /// </summary>
    public static class TargetIdFilterExtension {
        /// <summary>
        ///     Adds a "equal" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be equal in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<NodeIdFilter, DracoonFilterType<NodeIdFilter>> EqualTo(this NodeIdFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<NodeIdFilter, DracoonFilterType<NodeIdFilter>>(ef, ef);
        }
    }

    #endregion

    #region AccessKey-Filter

    /// <summary>
    ///     Filter to get only results where the given accesskey is contained.
    /// </summary>
    public class AccessKeyFilter : DracoonFilterType<AccessKeyFilter> {
        internal AccessKeyFilter() {
            FilterName = "accessKey";
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.AccessKeyFilter"/>
    /// </summary>
    public static class AccessKeyFilterExtension {
        /// <summary>
        ///     Adds a "contains" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for which the extension is provided.</param>
        /// <param name="value">The value which should be contained the result for the specified field.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<AccessKeyFilter, DracoonFilterType<AccessKeyFilter>> Contains(this AccessKeyFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<AccessKeyFilter, DracoonFilterType<AccessKeyFilter>>(ef, ef);
        }
    }

    #endregion

    #region User-Filter

    public class UserFilter : DracoonFilterType<UserFilter> {
        internal UserFilter() {
            FilterTypeString += "user";
        }
    }

    public static class UserFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<UserFilter, DracoonFilterType<UserFilter>> Contains(this UserFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<UserFilter, DracoonFilterType<UserFilter>>(ef, ef);
        }
    }

    #endregion

    #region IsMember-Filter

    public class IsMemberFilter : DracoonFilterType<IsMemberFilter> {
        internal IsMemberFilter() {
            FilterTypeString += "isMember";
        }
    }

    public static class IsMemberFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<IsMemberFilter, DracoonFilterType<IsMemberFilter>> EqualTo(this IsMemberFilter ef, bool? value) {
            ef.AddOperatorAndValue(value?.ToString(CultureInfo.InvariantCulture).ToLowerInvariant() ?? "any", "eq", nameof(value));
            return new FilterParam<IsMemberFilter, DracoonFilterType<IsMemberFilter>>(ef, ef);
        }
    }

    #endregion

    #region KeyFilter-Filter

    public class KeyFilter : DracoonFilterType<KeyFilter> {
        internal KeyFilter() {
            FilterTypeString += "key";
        }
    }

    public static class KeyFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<KeyFilter, DracoonFilterType<KeyFilter>> EqualTo(this KeyFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<KeyFilter, DracoonFilterType<KeyFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<KeyFilter, DracoonFilterType<KeyFilter>> Contains(this KeyFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<KeyFilter, DracoonFilterType<KeyFilter>>(ef, ef);
        }

        public static FilterParam<KeyFilter, DracoonFilterType<KeyFilter>> StartsWith(this KeyFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "sw", nameof(value));
            return new FilterParam<KeyFilter, DracoonFilterType<KeyFilter>>(ef, ef);
        }
    }

    #endregion

    #region Value-Filter

    public class ValueFilter : DracoonFilterType<ValueFilter> {
        internal ValueFilter() {
            FilterTypeString += "value";
        }
    }

    public static class ValueFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<ValueFilter, DracoonFilterType<ValueFilter>> EqualTo(this ValueFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<ValueFilter, DracoonFilterType<ValueFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<ValueFilter, DracoonFilterType<ValueFilter>> Contains(this ValueFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<ValueFilter, DracoonFilterType<ValueFilter>>(ef, ef);
        }

        public static FilterParam<ValueFilter, DracoonFilterType<ValueFilter>> StartsWith(this ValueFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "sw", nameof(value));
            return new FilterParam<ValueFilter, DracoonFilterType<ValueFilter>>(ef, ef);
        }
    }

    #endregion

    #region Email-Filter

    public class EmailFilter : DracoonFilterType<EmailFilter> {
        internal EmailFilter() {
            FilterTypeString += "email";
        }
    }

    public static class EmailFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<EmailFilter, DracoonFilterType<EmailFilter>> Contains(this EmailFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<EmailFilter, DracoonFilterType<EmailFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualsTo/*'/>
        public static FilterParam<EmailFilter, DracoonFilterType<EmailFilter>> EqualsTo(this EmailFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<EmailFilter, DracoonFilterType<EmailFilter>>(ef, ef);
        }
    }

    #endregion

    #region UserName-Filter

    public class UserNameFilter : DracoonFilterType<UserNameFilter> {
        internal UserNameFilter() {
            FilterTypeString += "userName";
        }
    }

    public static class UserNameFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<UserNameFilter, DracoonFilterType<UserNameFilter>> Contains(this UserNameFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<UserNameFilter, DracoonFilterType<UserNameFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualsTo/*'/>
        public static FilterParam<UserNameFilter, DracoonFilterType<UserNameFilter>> EqualsTo(this UserNameFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<UserNameFilter, DracoonFilterType<UserNameFilter>>(ef, ef);
        }
    }

    #endregion

    #region Login-Filter

    public class LoginFilter : DracoonFilterType<LoginFilter> {
        internal LoginFilter() {
            FilterTypeString += "login";
        }
    }

    public static class LoginFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<LoginFilter, DracoonFilterType<LoginFilter>> Contains(this LoginFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<LoginFilter, DracoonFilterType<LoginFilter>>(ef, ef);
        }
    }

    #endregion

    #region FirstName-Filter

    public class FirstNameFilter : DracoonFilterType<FirstNameFilter> {
        internal FirstNameFilter() {
            FilterTypeString += "firstName";
        }
    }

    public static class FirstNameFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<FirstNameFilter, DracoonFilterType<FirstNameFilter>> Contains(this FirstNameFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<FirstNameFilter, DracoonFilterType<FirstNameFilter>>(ef, ef);
        }
    }

    #endregion

    #region LastName-Filter

    public class LastNameFilter : DracoonFilterType<LastNameFilter> {
        internal LastNameFilter() {
            FilterTypeString += "lastName";
        }
    }

    public static class LastNameFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<LastNameFilter, DracoonFilterType<LastNameFilter>> Contains(this LastNameFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<LastNameFilter, DracoonFilterType<LastNameFilter>>(ef, ef);
        }
    }

    #endregion

    #region IsLocked-Filter

    public class IsLockedFilter : DracoonFilterType<IsLockedFilter> {
        internal IsLockedFilter() {
            FilterTypeString += "isLocked";
        }
    }

    public static class IsLockedFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<IsLockedFilter, DracoonFilterType<IsLockedFilter>> EqualTo(this IsLockedFilter ef, bool value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<IsLockedFilter, DracoonFilterType<IsLockedFilter>>(ef, ef);
        }
    }

    #endregion

    #region EffectiveRoles-Filter

    public class EffectiveRolesFilter : DracoonFilterType<EffectiveRolesFilter> {
        internal EffectiveRolesFilter() {
            FilterTypeString += "effectiveRoles";
        }
    }

    public static class EffectiveRolesFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<EffectiveRolesFilter, DracoonFilterType<EffectiveRolesFilter>> EqualTo(this EffectiveRolesFilter ef, bool value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<EffectiveRolesFilter, DracoonFilterType<EffectiveRolesFilter>>(ef, ef);
        }
    }

    #endregion

    public class FlagFilter : BoolFilterBase<FlagFilter> {
        internal FlagFilter(string filterName) : base(filterName) {
        }
        internal FlagFilter(string filterName, bool anyAllowed) : base(filterName, anyAllowed) {
        }
    }

    public class GroupIdFilter : IdFilterBase<GroupIdFilter> {
        internal GroupIdFilter() : base("groupId") {
        }
        internal GroupIdFilter(string filterName) : base(filterName) {
        }
        internal GroupIdFilter(string filterName, FilterOperator filterOperator) : base(filterName, filterOperator) {
        }
    }

    public class RoomIdFilter : IdFilterBase<RoomIdFilter> {
        internal RoomIdFilter() : base("roomId") {
        }
        internal RoomIdFilter(string filterName) : base(filterName) {
        }
        internal RoomIdFilter(string filterName, FilterOperator filterOperator) : base(filterName, filterOperator) {
        }
    }


    #region AssignmentState-Filter

    public class AssignmentStateFilter : DracoonFilterType<AssignmentStateFilter> {
        internal AssignmentStateFilter() {
            FilterTypeString += "state";
        }
    }

    public static class AssignmentStateFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<AssignmentStateFilter, DracoonFilterType<AssignmentStateFilter>> EqualTo(this AssignmentStateFilter ef, PendingAssignmentState value) {
            string state = null;
            if (value == PendingAssignmentState.Waiting)
                state = "WAITING";
            else if (value == PendingAssignmentState.Denied)
                state = "DENIED";
            if (string.IsNullOrEmpty(state))
                return null;

            ef.AddOperatorAndValue(state, "eq", nameof(value));
            return new FilterParam<AssignmentStateFilter, DracoonFilterType<AssignmentStateFilter>>(ef, ef);
        }
    }

    #endregion

    #region timestampCreation

    /// <summary>
    ///     Filter to restrict the period of time.
    /// </summary>
    public class TimestampFilter : DracoonFilterType<TimestampFilter> {
        internal TimestampFilter(string filterName) {
            FilterName = filterName;
            FilterTypeString += FilterName;
        }
    }

    /// <summary>
    ///     Extends the functions for <see cref="Dracoon.Sdk.Filter.TimestampFilter"/>.
    /// </summary>
    public static class TimestampFilterExtension {
        /// <summary>
        ///     Adds a "greater or equal to" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for wich the extension is provided.</param>
        /// <param name="value">The value which should be greater or equal to in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<TimestampFilter, DracoonFilterType<TimestampFilter>> GreaterEqualTo(this TimestampFilter ef, DateTime value) {
            value.MustNotNull(nameof(value));
            ef.AddOperatorAndValue(value, "ge", nameof(value));
            return new FilterParam<TimestampFilter, DracoonFilterType<TimestampFilter>>(ef, ef);
        }

        /// <summary>
        ///     Adds a "less or equal to" filter for the extended filter class.
        /// </summary>
        /// <param name="ef">The class for wich the extension is provided.</param>
        /// <param name="value">The value which should be less or equal to in the result.</param>
        /// <returns>The filter parameter which can possibly add a additional condition. See also <seealso cref="Dracoon.Sdk.Filter.FilterParam{T, V}"/></returns>
        public static FilterParam<TimestampFilter, DracoonFilterType<TimestampFilter>> LessEqualTo(this TimestampFilter ef, DateTime value) {
            value.MustNotNull(nameof(value));
            ef.AddOperatorAndValue(value, "le", nameof(value));
            return new FilterParam<TimestampFilter, DracoonFilterType<TimestampFilter>>(ef, ef);
        }

        /// <summary>
        ///     Adds a "and" operator to concat multiple filters.
        /// </summary>
        /// <param name="ef">The class for wich the extension is provided.</param>
        /// <returns>The extended class itself with the possibility to add a additional filter.</returns>
        public static TimestampFilter And(this FilterParam<TimestampFilter, DracoonFilterType<TimestampFilter>> ef) {
            ef.Parent.AddAnd();
            return ef.Parent;
        }
    }

    #endregion
}
