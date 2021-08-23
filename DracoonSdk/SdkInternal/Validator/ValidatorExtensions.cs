using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dracoon.Sdk.Error;

namespace Dracoon.Sdk.SdkInternal.Validator {
    internal static class ValidatorExtensions {
        private static readonly string[] InvalidPathChars = { "<", ">", ":", "\"", "|", "?", "*" };

        internal static void MustNotNull<T>(this T param, string paramName) {
            if (param == null) {
                throw new ArgumentNullException(paramName);
            }
        }

        internal static void MustHaveValue<T>(this T? param, string paramName) where T : struct {
            if (!param.HasValue) {
                throw new ArgumentNullException(paramName);
            }
        }

        internal static void MustNotBeDefault<T>(this T param, string paramName) {
            if (null == param || param.Equals(default(T))) {
                throw new ArgumentException(paramName + " must not have a default value.");
            }
        }


        internal static void EnumerableMustNotNullOrEmpty<T>(this IEnumerable<T> param, string paramName) {
            param.MustNotNull(paramName);
            if (!param.Any()) {
                throw new ArgumentException(paramName + " cannot be empty.");
            }
        }

        internal static bool CheckEnumerableNullOrEmpty<T>(this IEnumerable<T> param) {
            if (param == null) {
                return true;
            }
            if (!param.Any()) {
                return true;
            }

            return false;
        }

        internal static void MustNotNullOrEmptyOrWhitespace(this string param, string paramName, bool nullAllowed = false) {
            if (!nullAllowed) {
                param.MustNotNull(paramName);
            } else if (param == null) {
                return;
            }

            if (param.Length == 0) {
                throw new ArgumentException(paramName + " cannot be empty.");
            }

            int whitespaces = 0;
            foreach (char current in param) {
                if (char.IsWhiteSpace(current)) {
                    whitespaces++;
                }
            }

            if (param.Length == whitespaces) {
                throw new ArgumentException(paramName + " cannot be whitespace.");
            }
        }

        internal static void MustValidNodePath(this string param, string paramName) {
            param.MustNotNullOrEmptyOrWhitespace(paramName);
            if (param == "/") {
                throw new ArgumentException("You cannot request the root because it has no usable node object.");
            }

            if (!param.StartsWith("/")) {
                throw new ArgumentException("The node path must start with '/'.");
            }

            if (param.EndsWith("/")) {
                throw new ArgumentException("The node path cannot end with '/'.");
            }

            if (param.Length > 4096) {
                throw new ArgumentException("The node path is to long. Only a path length up to 4096 chars are allowed.");
            }

            List<string> foundInvalidChars = new List<string>(InvalidPathChars.Length);
            foundInvalidChars.AddRange(InvalidPathChars.Where(param.Contains));

            if (foundInvalidChars.Count > 0) {
                throw new ArgumentException("The node path cannot contain " + string.Join(",", foundInvalidChars.ToArray()) + ".");
            }
        }

        internal static void CheckStreamCanRead(this Stream param, string paramName) {
            param.MustNotNull(paramName);
            if (!param.CanRead) {
                throw new DracoonFileIOException("Cannot read from the given stream.");
            }
        }

        internal static void CheckStreamCanWrite(this Stream param, string paramName) {
            param.MustNotNull(paramName);
            if (!param.CanWrite) {
                throw new DracoonFileIOException("Cannot write to the given stream.");
            }
        }

        internal static void MustBeValid(this Uri param, string paramName) {
            param.MustNotNull(paramName);
            if (string.IsNullOrWhiteSpace(param.Scheme) || !(param.Scheme == Uri.UriSchemeHttp || param.Scheme == Uri.UriSchemeHttps)) {
                throw new ArgumentException("Server URI can only have protocol http or https.");
            }

            if (!string.IsNullOrWhiteSpace(param.UserInfo)) {
                throw new ArgumentException("Server URI cannot have a user.");
            }

            if (!string.IsNullOrWhiteSpace(param.Query)) {
                throw new ArgumentException("Server URI cannot have a query.");
            }
        }

        #region Numeric checks

        internal static void MustPositive(this long param, string paramName) {
            param.MustNotNull(paramName);
            if (param <= 0) {
                throw new ArgumentException(paramName + " cannot be negative or 0.");
            }
        }

        internal static void MustPositive(this int param, string paramName) {
            param.MustNotNull(paramName);
            if (param <= 0) {
                throw new ArgumentException(paramName + " cannot be negative or 0.");
            }
        }

        internal static void MustNotNegative(this long param, string paramName) {
            param.MustNotNull(paramName);
            if (param < 0) {
                throw new ArgumentException(paramName + " cannot be negative.");
            }
        }

        internal static void MustNotNegative(this int param, string paramName) {
            param.MustNotNull(paramName);
            if (param < 0) {
                throw new ArgumentException(paramName + " cannot be negative.");
            }
        }

        internal static void NullableMustPositive(this long? param, string paramName) {
            if (param.HasValue && param.Value <= 0) {
                throw new ArgumentException(paramName + " cannot be negative or 0.");
            }
        }

        internal static void NullableMustPositive(this int? param, string paramName) {
            if (param.HasValue && param.Value <= 0) {
                throw new ArgumentException(paramName + " cannot be negative or 0.");
            }
        }

        internal static void NullableMustNotNegative(this long? param, string paramName) {
            if (param.HasValue && param.Value < 0) {
                throw new ArgumentException(paramName + " cannot be negative.");
            }
        }

        internal static void NullableMustNotNegative(this int? param, string paramName) {
            if (param.HasValue && param.Value < 0) {
                throw new ArgumentException(paramName + " cannot be negative.");
            }
        }

        internal static void MustBetween(this long? param, string paramName, long lowerBound, long upperBound) {
            if (param.HasValue && (param.Value < lowerBound || param.Value > upperBound)) {
                throw new ArgumentException($"{paramName} must be in range [{lowerBound} ... {upperBound}].");
            }
        }

        internal static void MustBetween(this int? param, string paramName, int lowerBound, int upperBound) {
            if (param.HasValue && (param.Value < lowerBound || param.Value > upperBound)) {
                throw new ArgumentException($"{paramName} must be in range [{lowerBound} ... {upperBound}].");
            }
        }

        #endregion
    }
}
