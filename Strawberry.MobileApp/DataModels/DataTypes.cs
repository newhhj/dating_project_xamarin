using System;
using System.Collections.Generic;
using System.Text;

namespace Strawberry.MobileApp.DataModels
{
    public enum MemberStateTypes
    {
        Normal = 0,
        Block,
        JoinWait,
        JoinConfirm,
        JoinDeny
    }

    public enum GenderTypes
    {
        Male = 0,
        Female
    }

    public enum LevelTypes
    {
        Silver = 0,
        Gold = 1,
        Platinum = 2,
        Diamond = 3
    }

    public enum PriorityTypes
    {
        None = 0,
        BeautyOrWealth,
        Age,
        Range,
        Tall,
        Body,
        Religion,
        Alcohol,
        Smoking
    }

    public enum MessageTypes
    {
        Text = 0,
        Image,
        Voice,
        Wait,
        Close,
        StarPoint
    }

    public enum AppraisalTypes
    {
        Manner = 0,
        BadManner
    }
}
