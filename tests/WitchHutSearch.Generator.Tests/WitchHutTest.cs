﻿using WitchHutSearch.Generator.Features;
using Xunit;

namespace WitchHutSearch.Generator.Tests;

public class WitchHutTest
{
    [Fact]
    public void TestWitchHutLocator()
    {
        const ulong seed = 10579846526078875722;

        var expected = new Pos(352, 176);
        var pos = new Pos(0, 0);
        var output = new Pos();
        FeatureLocator.WitchHut.GetPosition(seed, pos, ref output);
        Assert.Equal((expected.X, expected.Z), (output.X, output.Z));

        expected.X = -17392;
        expected.Z = 26944;
        pos.X = -34;
        pos.Z = 52;
        FeatureLocator.WitchHut.GetPosition(seed, pos, ref output);
        Assert.Equal((expected.X, expected.Z), (output.X, output.Z));
    }

    [Fact]
    public void TestWitchHutWithBiome()
    {
        const ulong seed = 10579846526078875722;
        var pos = new Pos();
        var g = new BiomeGenerator(seed);
        FeatureLocator.WitchHut.GetPosition(seed, new Pos(-15, -34), ref pos);
        var biomeId = g.GetBiomeAtPos(pos);
        Assert.NotEqual(6, biomeId);
    }
}