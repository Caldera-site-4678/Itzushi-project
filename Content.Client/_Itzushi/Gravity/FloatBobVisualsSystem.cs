using Content.Shared._Itzushi.Gravity;
using Robust.Client.GameObjects;
using Robust.Shared.Timing;
using System.Numerics;

namespace Content.Client._Itzushi.Gravity;

/// <summary>
/// handles visual bobbing for floating entities
/// this only changes the sprite offset on the client ONLY
/// </summary>

public sealed class FloatBobVisualsSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var time = (float) _timing.CurTime.TotalSeconds;
        var query = EntityQueryEnumerator<FloatBobVisualsComponent, SpriteComponent>();

        while (query.MoveNext(out var uid, out var bob, out var sprite))
        {
            if (!bob.BaseOffsetSet)
            {
                bob.BaseOffset = sprite.Offset;
                bob.BaseOffsetSet = true;
            }

            var yOffset = MathF.Sin(time * MathF.Tau * bob.Frequency) * bob.Amplitude;
            sprite.Offset = bob.BaseOffset + new Vector2(0f, yOffset);
        }
    }
}