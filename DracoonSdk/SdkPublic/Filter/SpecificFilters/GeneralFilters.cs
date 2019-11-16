using System;
using System.Globalization;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.Validator;

namespace Dracoon.Sdk.Filter {

    #region Base Types

    [Flags]
    public enum FilterOperator : int {
        None = 0,

        Equals = 1 << 0,
        Contains = 1 << 1,
        StartsWith = 1 << 2,
    }

    public interface IFilter {
        FilterOperator DefaultOperators { get; }

        FilterOperator FilterOperators { get; }
    }

    public abstract class FilterBase<TFilter> : DracoonFilterType<TFilter>, IFilter where TFilter : IFilter {
        internal FilterBase(string filterName) {
            filterTypeString += filterName;
            FilterOperators = DefaultOperators;
        }
        internal FilterBase(string filterName, FilterOperator filterOperators) {
            filterTypeString += filterName;
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

    #endregion

    #region NodeType-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NodeTypeFilter/*'/>
    public class NodeTypeFilter : DracoonFilterType<NodeTypeFilter> {
        internal NodeTypeFilter() {
            filterTypeString += "type";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NodeTypeFilterExtension/*'/>
    public static class NodeTypeFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Or/*'/>
        public static NodeTypeFilter Or(this FilterParam<NodeTypeFilter, DracoonFilterType<NodeTypeFilter>> ef) {
            return ef.parent;
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<NodeTypeFilter, DracoonFilterType<NodeTypeFilter>> EqualTo(this NodeTypeFilter ef, NodeType value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<NodeTypeFilter, DracoonFilterType<NodeTypeFilter>>(ef, ef);
        }
    }

    #endregion

    #region IsFavorite-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/IsFavoriteFilter/*'/>
    public class IsFavoriteFilter : DracoonFilterType<IsFavoriteFilter> {
        internal IsFavoriteFilter() {
            filterTypeString += "isFavorite";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NodeIsFavoriteFilterExtension/*'/>
    public static class NodeIsFavoriteFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<IsFavoriteFilter, DracoonFilterType<IsFavoriteFilter>> EqualTo(this IsFavoriteFilter ef, bool value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<IsFavoriteFilter, DracoonFilterType<IsFavoriteFilter>>(ef, ef);
        }
    }

    #endregion

    #region Name-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NameFilter/*'/>
    public class NameFilter : TextFilterBase<NameFilter> {
        internal NameFilter() : base("name") {
        }
        internal NameFilter(string filterName) : base(filterName) {
        }
        internal NameFilter(string filterName, FilterOperator filterOperators) : base(filterName, filterOperators) {
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NodeNameFilterExtension/*'/>
    public static class NodeNameFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<NameFilter, DracoonFilterType<NameFilter>> Contains(this NameFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<NameFilter, DracoonFilterType<NameFilter>>(ef, ef);
        }
    }

    #endregion

    #region IsEncrypted-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NodeIsEncryptedFilter/*'/>
    public class NodeIsEncryptedFilter : DracoonFilterType<NodeIsEncryptedFilter> {
        internal NodeIsEncryptedFilter() {
            filterTypeString += "encrypted";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/NodeIsEncryptedFilterExtension/*'/>
    public static class NodeIsEncryptedFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<NodeIsEncryptedFilter, DracoonFilterType<NodeIsEncryptedFilter>> EqualTo(this NodeIsEncryptedFilter ef, bool value) {
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<NodeIsEncryptedFilter, DracoonFilterType<NodeIsEncryptedFilter>>(ef, ef);
        }
    }

    #endregion

    #region UserId-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/UserIdFilter/*'/>
    public class UserIdFilter : IdFilterBase<UserIdFilter> {
        internal UserIdFilter() : base("userId") {
        }
        internal UserIdFilter(string filterName) : base(filterName) {
        }

        internal UserIdFilter(string filterName, FilterOperator filterOperators) : base(filterName, filterOperators) {
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/UserIdFilterExtension/*'/>
    public static class UserIdFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<UserIdFilter, DracoonFilterType<UserIdFilter>> EqualTo(this UserIdFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<UserIdFilter, DracoonFilterType<UserIdFilter>>(ef, ef);
        }
    }

    #endregion

    #region UpdatedBy-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/UpdatedByFilter/*'/>
    public class UpdatedByFilter : DracoonFilterType<UpdatedByFilter> {
        internal UpdatedByFilter() {
            filterTypeString += "updatedBy";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/UpdatedByFilterExtension/*'/>
    public static class UpdatedByFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>> EqualTo(this UpdatedByFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>> Contains(this UpdatedByFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<UpdatedByFilter, DracoonFilterType<UpdatedByFilter>>(ef, ef);
        }
    }


    #endregion

    #region ParentPath-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/ParentPathFilter/*'/>
    public class ParentPathFilter : DracoonFilterType<ParentPathFilter> {
        internal ParentPathFilter() {
            filterTypeString += "parentPath";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/ParentPathFilterExtension/*'/>
    public static class ParentPathFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>> EqualTo(this ParentPathFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>> Contains(this ParentPathFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<ParentPathFilter, DracoonFilterType<ParentPathFilter>>(ef, ef);
        }
    }

    #endregion

    #region FileType-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/FileTypeFilter/*'/>
    public class FileTypeFilter : DracoonFilterType<FileTypeFilter> {
        internal FileTypeFilter() {
            filterTypeString += "fileType";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/FileTypeFilterExtension/*'/>
    public static class FileTypeFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>> EqualTo(this FileTypeFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>>(ef, ef);
        }

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>> Contains(this FileTypeFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<FileTypeFilter, DracoonFilterType<FileTypeFilter>>(ef, ef);
        }
    }

    #endregion

    #region Classification-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/ClassificationFilter/*'/>
    public class ClassificationFilter : DracoonFilterType<ClassificationFilter> {
        internal ClassificationFilter() {
            filterTypeString += "classification";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/ClassificationFilterExtension/*'/>
    public static class ClassificationFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<ClassificationFilter, DracoonFilterType<ClassificationFilter>> EqualTo(this ClassificationFilter ef, Classification value) {
            ef.AddOperatorAndValue((int)value, "eq", nameof(value));
            return new FilterParam<ClassificationFilter, DracoonFilterType<ClassificationFilter>>(ef, ef);
        }
    }

    #endregion

    #region CreatedBy-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/CreatedByFilter/*'/>
    public class CreatedByFilter : DracoonFilterType<CreatedByFilter> {
        internal CreatedByFilter() {
            filterTypeString += "createdBy";
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/CreatedByFilterExtension/*'/>
    public static class CreatedByFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<CreatedByFilter, DracoonFilterType<CreatedByFilter>> Contains(this CreatedByFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<CreatedByFilter, DracoonFilterType<CreatedByFilter>>(ef, ef);
        }
    }

    #endregion

    #region NodeId_TargetId-Filter

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/TargetIdFilter/*'/>
    public class NodeIdFilter : IdFilterBase<NodeIdFilter> {
        internal NodeIdFilter() : base("nodeId") {
        }
        internal NodeIdFilter(string filterName) : base(filterName) {
        }
        internal NodeIdFilter(string filterName, FilterOperator filterOperators) : base(filterName, filterOperators) {
        }
    }

    /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="generalFilters"]/TargetIdFilterExtension/*'/>
    public static class TargetIdFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/EqualTo/*'/>
        public static FilterParam<NodeIdFilter, DracoonFilterType<NodeIdFilter>> EqualTo(this NodeIdFilter ef, long value) {
            value.MustPositive(nameof(value));
            ef.AddOperatorAndValue(value, "eq", nameof(value));
            return new FilterParam<NodeIdFilter, DracoonFilterType<NodeIdFilter>>(ef, ef);
        }
    }

    #endregion

    #region User-Filter

    public class UserFilter : DracoonFilterType<UserFilter> {
        internal UserFilter() {
            filterTypeString += "user";
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
            filterTypeString += "isMember";
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
            filterTypeString += "key";
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
            filterTypeString += "value";
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
            filterTypeString += "email";
        }
    }

    public static class EmailFilterExtension {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="general"]/Contains/*'/>
        public static FilterParam<EmailFilter, DracoonFilterType<EmailFilter>> Contains(this EmailFilter ef, string value) {
            value.MustNotNullOrEmptyOrWhitespace(nameof(value));
            ef.AddOperatorAndValue(value, "cn", nameof(value));
            return new FilterParam<EmailFilter, DracoonFilterType<EmailFilter>>(ef, ef);
        }
    }

    #endregion

    #region UserName-Filter

    public class UserNameFilter : DracoonFilterType<UserNameFilter> {
        internal UserNameFilter() {
            filterTypeString += "userName";
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
            filterTypeString += "login";
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
            filterTypeString += "firstName";
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
            filterTypeString += "lastName";
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
            filterTypeString += "isLocked";
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
            filterTypeString += "effectiveRoles";
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
            filterTypeString += "state";
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
}
