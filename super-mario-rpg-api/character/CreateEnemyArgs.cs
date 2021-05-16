namespace SuperMarioRpg.Api
{
    public record CreateEnemyArgs(
        string Name,
        short HitPoints,
        byte FlowerPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal Evade,
        decimal MagicEvade
    );
}
