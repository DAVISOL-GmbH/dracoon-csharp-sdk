using Dracoon.Sdk.Model;

namespace Dracoon.Sdk.SdkInternal.Util {
    internal static class EnumConverter {

        public static NodeType ConvertValueToNodeTypeEnum(string value) {
            if (value == "room") {
                return NodeType.Room;
            } else if (value == "folder") {
                return NodeType.Folder;
            } else {
                return NodeType.File;
            }
        }

        public static string ConvertNodeTypeEnumToValue(NodeType typeEnum) {
            if (typeEnum == NodeType.Room) {
                return "room";
            } else if (typeEnum == NodeType.Folder) {
                return "folder";
            } else {
                return "file";
            }
        }

        public static Classification? ConvertValueToClassificationEnum(int? value) {
            switch (value) {
                case 1:
                    return Classification.Public;
                case 2:
                    return Classification.Internal;
                case 3:
                    return Classification.Confidential;
                case 4:
                    return Classification.StrictlyConfidential;
                default:
                    return null;
            }
        }

        public static int? ConvertClassificationEnumToValue(Classification? classificationEnum) {
            switch (classificationEnum) {
                case Classification.Public:
                    return 1;
                case Classification.Internal:
                    return 2;
                case Classification.Confidential:
                    return 3;
                case Classification.StrictlyConfidential:
                    return 4;
                default:
                    return null;
            }
        }

        public static string ConvertGroupMemberAcceptanceToValue(GroupMemberAcceptance? gma) {
            switch (gma) {
                case GroupMemberAcceptance.AutoAllow:
                    return "autoallow";
                case GroupMemberAcceptance.Pending:
                    return "pending";
                default:
                    return null;
            }
        }

        public static GroupMemberAcceptance? ConvertValueToGroupMemberAcceptance(string value) {
            if (string.IsNullOrEmpty(value))
                return null;
            if (value == "autoallow")
                return GroupMemberAcceptance.AutoAllow;
            if (value == "pending")
                return GroupMemberAcceptance.Pending;
            return null;
        }

        public static string ConvertResolutionStrategyToValue(ResolutionStrategy strategy) {
            switch (strategy) {
                case ResolutionStrategy.AutoRename:
                    return "autorename";
                case ResolutionStrategy.Fail:
                    return "fail";
                case ResolutionStrategy.Overwrite:
                    return "overwrite";
                default:
                    return null;
            }
        }

        public static PendingAssignmentState? ConvertValueToPendingAssignmentState(string value) {
            if (string.IsNullOrEmpty(value))
                return null;
            if (value == "ACCEPTED")
                return PendingAssignmentState.Accepted;
            if (value == "WAITING")
                return PendingAssignmentState.Waiting;
            if (value == "DENIED")
                return PendingAssignmentState.Denied;
            return null;
        }

        public static string ConvertUserTypeToValue(UserType userType) {
            switch (userType) {
                case UserType.Internal:
                    return "internal";
                case UserType.External:
                    return "external";
                case UserType.System:
                    return "system";
                case UserType.Deleted:
                    return "deleted";
                default:
                    return null;
            }
        }

        public static UserType? ConvertValueToUserType(string value) {
            if (string.IsNullOrEmpty(value))
                return null;
            if (value == "internal")
                return UserType.Internal;
            if (value == "external")
                return UserType.External;
            if (value == "system")
                return UserType.System;
            if (value == "deleted")
                return UserType.Deleted;
            return null;
        }
    }
}
