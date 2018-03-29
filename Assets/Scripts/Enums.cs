/// <summary>
/// Список игровых сцен
/// </summary>
public enum SceneNames
{
    Start,
    Level1,
    Level2,
    Level3,
    SelectCharacter,
    SelectLevel,
    Battle
}

/// <summary>
/// Список доступного дополнительного оружия
/// </summary>
public enum AdditionalWeapon
{
    Pistol,
    Machinegun,
    Shotgun
}

/// <summary>
/// Список доступных навыков
/// </summary>
public enum Skill
{
    Ice,
    Fire,
    Thunder
}

/// <summary>
/// Список доступного основого оружия
/// </summary>
public enum MainWeapon
{
    Axe
}

/// <summary>
/// Список состояний игровой сессии
/// </summary>
public enum State
{
    Start,
    SelectLevel,
    SelectCharacter,
    Modal,
    Play
}

