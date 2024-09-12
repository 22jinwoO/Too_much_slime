// 유닛 상태
public enum unitState
{
    Default = 0,
    Idle = 1,
    Move = 2,
    Attack = 3,
    UseSkill = 4,
    Dead = 5,
    End = Dead + 1
}

public enum cardType
{
    Default = 0,
    Fire = 1,
    Ice = 2,
    Ground = 3,
    Wind = 4,
    End = Wind + 1
}
