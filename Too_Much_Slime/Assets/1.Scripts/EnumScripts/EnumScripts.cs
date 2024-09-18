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
    Fire = 0,
    Ice = 1,
    Wind = 2,
    Ground = 3,
    End = Wind + 1
}
