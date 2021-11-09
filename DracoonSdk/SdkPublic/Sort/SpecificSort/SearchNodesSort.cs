﻿namespace Dracoon.Sdk.Sort {

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
    /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/SearchNodesSort/*'/>
    public class SearchNodesSort : DracoonSort {
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/UpdatedAt/*'/>
        public static SortField<SearchNodesSort> UpdatedAt {
            get {
                return new SortField<SearchNodesSort>(new SearchNodesSort(), "updatedAt");
            }
        }

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/Size/*'/>
        public static SortField<SearchNodesSort> Size {
            get {
                return new SortField<SearchNodesSort>(new SearchNodesSort(), "size");
            }
        }

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/CreatedAt/*'/>
        public static SortField<SearchNodesSort> CreatedAt {
            get {
                return new SortField<SearchNodesSort>(new SearchNodesSort(), "createdAt");
            }
        }

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/Name/*'/>
        public static SortField<SearchNodesSort> Name {
            get {
                return new SortField<SearchNodesSort>(new SearchNodesSort(), "name");
            }
        }

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/ModificationTimestamp/*'/>
        public static SortField<SearchNodesSort> ModificationTimestamp {
            get {
                return new SortField<SearchNodesSort>(new SearchNodesSort(), "timestampModification");
            }
        }

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/CreationTimestamp/*'/>
        public static SortField<SearchNodesSort> CreationTimestamp {
            get {
                return new SortField<SearchNodesSort>(new SearchNodesSort(), "timestampCreation");
            }
        }
    }
}