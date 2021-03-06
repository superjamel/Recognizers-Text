﻿using System.Collections.Immutable;
using System.Text.RegularExpressions;

using Microsoft.Recognizers.Text.Number;

namespace Microsoft.Recognizers.Text.DateTime.French
{
    public class FrenchDurationParserConfiguration : BaseOptionsConfiguration, IDurationParserConfiguration
    {
        public IExtractor CardinalExtractor { get; }

        public IExtractor DurationExtractor { get; }

        public IParser NumberParser { get; }

        public Regex NumberCombinedWithUnit { get; }

        public Regex AnUnitRegex { get; }

        public Regex DuringRegex { get; }

        public Regex AllDateUnitRegex { get; }

        public Regex HalfDateUnitRegex { get; }

        public Regex SuffixAndRegex { get; }

        public Regex FollowedUnit { get; }

        public Regex ConjunctionRegex { get; }

        public Regex InexactNumberRegex { get; }

        public Regex InexactNumberUnitRegex { get; }

        public Regex DurationUnitRegex { get; }

        public IImmutableDictionary<string, string> UnitMap { get; }

        public IImmutableDictionary<string, long> UnitValueMap { get; }

        public IImmutableDictionary<string, double> DoubleNumbers { get; }

        public FrenchDurationParserConfiguration(ICommonDateTimeParserConfiguration config) : base(config.Options)
        {
            CardinalExtractor = config.CardinalExtractor;
            NumberParser = config.NumberParser;
            DurationExtractor = new BaseDurationExtractor(new FrenchDurationExtractorConfiguration(), false);
            NumberCombinedWithUnit = FrenchDurationExtractorConfiguration.NumberCombinedWithDurationUnit;
            AnUnitRegex = FrenchDurationExtractorConfiguration.AnUnitRegex;
            DuringRegex = FrenchDurationExtractorConfiguration.DuringRegex;
            AllDateUnitRegex = FrenchDurationExtractorConfiguration.AllRegex;
            HalfDateUnitRegex = FrenchDurationExtractorConfiguration.HalfRegex;
            SuffixAndRegex = FrenchDurationExtractorConfiguration.SuffixAndRegex;
            FollowedUnit = FrenchDurationExtractorConfiguration.DurationFollowedUnit;
            ConjunctionRegex = FrenchDurationExtractorConfiguration.ConjunctionRegex;
            InexactNumberRegex = FrenchDurationExtractorConfiguration.InexactNumberRegex;
            InexactNumberUnitRegex = FrenchDurationExtractorConfiguration.InexactNumberUnitRegex;
            DurationUnitRegex = FrenchDurationExtractorConfiguration.DurationUnitRegex;
            UnitMap = config.UnitMap;
            UnitValueMap = config.UnitValueMap;
            DoubleNumbers = config.DoubleNumbers;
        }
    }
}
