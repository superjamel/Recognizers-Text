﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

using Microsoft.Recognizers.Definitions.German;

namespace Microsoft.Recognizers.Text.Number.German
{
    public class DoubleExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, string> Regexes { get; }

        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_DOUBLE; // "Double";

        private static readonly ConcurrentDictionary<string, DoubleExtractor> Instances = new ConcurrentDictionary<string, DoubleExtractor>();

        public static DoubleExtractor GetInstance(string placeholder = NumbersDefinitions.PlaceHolderDefault)
        {

            if (!Instances.ContainsKey(placeholder))
            {
                var instance = new DoubleExtractor(placeholder);
                Instances.TryAdd(placeholder, instance);
            }

            return Instances[placeholder];
        }

        private DoubleExtractor(string placeholder = NumbersDefinitions.PlaceHolderDefault)
        {
            var regexes = new Dictionary<Regex, string> {
                {
                    new Regex(NumbersDefinitions.DoubleDecimalPointRegex(placeholder),
                              RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "DoubleNum"
                }, {
                    new Regex(NumbersDefinitions.DoubleWithoutIntegralRegex(placeholder),
                              RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "DoubleNum"
                }, {
                    new Regex(NumbersDefinitions.DoubleWithMultiplierRegex, RegexOptions.Singleline),
                    "DoubleNum"
                }, {
                    new Regex(NumbersDefinitions.DoubleWithRoundNumber, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "DoubleNum"
                }, {
                    new Regex(NumbersDefinitions.DoubleAllFloatRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "DoubleGer"
                }, {
                    new Regex(NumbersDefinitions.DoubleExponentialNotationRegex,
                              RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "DoublePow"
                }, {
                    new Regex(NumbersDefinitions.DoubleCaretExponentialNotationRegex,
                              RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "DoublePow"
                }, {
                    GenerateLongFormatNumberRegexes(LongFormatType.DoubleNumDotComma, placeholder), "DoubleNum"
                }, {
                    GenerateLongFormatNumberRegexes(LongFormatType.DoubleNumNoBreakSpaceComma, placeholder), "DoubleNum"
                }
            };

            Regexes = regexes.ToImmutableDictionary();
        }
    }
}