using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexing
{
    /// <summary>
    /// The following references were used:
    /// http://msdn.microsoft.com/en-us/library/20bw873z.aspx#CategoryOrBlock
    /// http://www.codeproject.com/Articles/11598/Unicode-Character-Category-Helper
    /// </summary>
    internal static class CharacterSetUnicodeExtensions
    {
        #region AddCategories

        public static CharacterSet AddCategories(this CharacterSet set, params string[] categoryNames)
        {
            foreach (var categoryName in categoryNames)
                set.AddCategory(categoryName);

            return set;
        }

        #endregion //AddCategories

        #region AddCategory

        public static CharacterSet AddCategory(this CharacterSet set, string categoryName)
        {
            switch (categoryName)
            {
				case "Lu":
					AddCategoryLu(set);
					break;
				case "Ll":
					AddCategoryLl(set);
					break;
				case "Lt":
					AddCategoryLt(set);
					break;
				case "Lm":
					AddCategoryLm(set);
					break;
				case "Lo":
					AddCategoryLo(set);
					break;
				case "L":
					AddCategoryL(set);
					break;
				case "Mn":
					AddCategoryMn(set);
					break;
				case "Mc":
					AddCategoryMc(set);
					break;
				case "Me":
					AddCategoryMe(set);
					break;
				case "M":
					AddCategoryM(set);
					break;
				case "Nd":
					AddCategoryNd(set);
					break;
				case "Nl":
					AddCategoryNl(set);
					break;
				case "No":
					AddCategoryNo(set);
					break;
				case "N":
					AddCategoryN(set);
					break;
				case "Pc":
					AddCategoryPc(set);
					break;
				case "Pd":
					AddCategoryPd(set);
					break;
				case "Ps":
					AddCategoryPs(set);
					break;
				case "Pe":
					AddCategoryPe(set);
					break;
				case "Pi":
					AddCategoryPi(set);
					break;
				case "Pf":
					AddCategoryPf(set);
					break;
				case "Po":
					AddCategoryPo(set);
					break;
				case "P":
					AddCategoryP(set);
					break;
				case "Sm":
					AddCategorySm(set);
					break;
				case "Sc":
					AddCategorySc(set);
					break;
				case "Sk":
					AddCategorySk(set);
					break;
				case "So":
					AddCategorySo(set);
					break;
				case "S":
					AddCategoryS(set);
					break;
				case "Zs":
					AddCategoryZs(set);
					break;
				case "Zl":
					AddCategoryZl(set);
					break;
				case "Zp":
					AddCategoryZp(set);
					break;
				case "Z":
					AddCategoryZ(set);
					break;
				case "Cc":
					AddCategoryCc(set);
					break;
				case "Cf":
					AddCategoryCf(set);
					break;
				case "Cs":
					AddCategoryCs(set);
					break;
				case "Co":
					AddCategoryCo(set);
					break;
				case "Cn":
					AddCategoryCn(set);
					break;
				case "C":
					AddCategoryC(set);
					break;
				case "IsBasicLatin":
					set.AddRange('\u0000','\u007F');
					break;
				case "IsLatin-1Supplement":
					set.AddRange('\u0080','\u00FF');
					break;
				case "IsLatinExtended-A":
					set.AddRange('\u0100','\u017F');
					break;
				case "IsLatinExtended-B":
					set.AddRange('\u0180','\u024F');
					break;
				case "IsIPAExtensions":
					set.AddRange('\u0250','\u02AF');
					break;
				case "IsSpacingModifierLetters":
					set.AddRange('\u02B0','\u02FF');
					break;
				case "IsCombiningDiacriticalMarks":
					set.AddRange('\u0300','\u036F');
					break;
				case "IsGreek":
					set.AddRange('\u0370','\u03FF');
					break;
				case "IsGreekandCoptic":
					set.AddRange('\u0370','\u03FF');
					break;
				case "IsCyrillic":
					set.AddRange('\u0400','\u04FF');
					break;
				case "IsCyrillicSupplement":
					set.AddRange('\u0500','\u052F');
					break;
				case "IsArmenian":
					set.AddRange('\u0530','\u058F');
					break;
				case "IsHebrew":
					set.AddRange('\u0590','\u05FF');
					break;
				case "IsArabic":
					set.AddRange('\u0600','\u06FF');
					break;
				case "IsSyriac":
					set.AddRange('\u0700','\u074F');
					break;
				case "IsThaana":
					set.AddRange('\u0780','\u07BF');
					break;
				case "IsDevanagari":
					set.AddRange('\u0900','\u097F');
					break;
				case "IsBengali":
					set.AddRange('\u0980','\u09FF');
					break;
				case "IsGurmukhi":
					set.AddRange('\u0A00','\u0A7F');
					break;
				case "IsGujarati":
					set.AddRange('\u0A80','\u0AFF');
					break;
				case "IsOriya":
					set.AddRange('\u0B00','\u0B7F');
					break;
				case "IsTamil":
					set.AddRange('\u0B80','\u0BFF');
					break;
				case "IsTelugu":
					set.AddRange('\u0C00','\u0C7F');
					break;
				case "IsKannada":
					set.AddRange('\u0C80','\u0CFF');
					break;
				case "IsMalayalam":
					set.AddRange('\u0D00','\u0D7F');
					break;
				case "IsSinhala":
					set.AddRange('\u0D80','\u0DFF');
					break;
				case "IsThai":
					set.AddRange('\u0E00','\u0E7F');
					break;
				case "IsLao":
					set.AddRange('\u0E80','\u0EFF');
					break;
				case "IsTibetan":
					set.AddRange('\u0F00','\u0FFF');
					break;
				case "IsMyanmar":
					set.AddRange('\u1000','\u109F');
					break;
				case "IsGeorgian":
					set.AddRange('\u10A0','\u10FF');
					break;
				case "IsHangulJamo":
					set.AddRange('\u1100','\u11FF');
					break;
				case "IsEthiopic":
					set.AddRange('\u1200','\u137F');
					break;
				case "IsCherokee":
					set.AddRange('\u13A0','\u13FF');
					break;
				case "IsUnifiedCanadianAboriginalSyllabics":
					set.AddRange('\u1400','\u167F');
					break;
				case "IsOgham":
					set.AddRange('\u1680','\u169F');
					break;
				case "IsRunic":
					set.AddRange('\u16A0','\u16FF');
					break;
				case "IsTagalog":
					set.AddRange('\u1700','\u171F');
					break;
				case "IsHanunoo":
					set.AddRange('\u1720','\u173F');
					break;
				case "IsBuhid":
					set.AddRange('\u1740','\u175F');
					break;
				case "IsTagbanwa":
					set.AddRange('\u1760','\u177F');
					break;
				case "IsKhmer":
					set.AddRange('\u1780','\u17FF');
					break;
				case "IsMongolian":
					set.AddRange('\u1800','\u18AF');
					break;
				case "IsLimbu":
					set.AddRange('\u1900','\u194F');
					break;
				case "IsTaiLe":
					set.AddRange('\u1950','\u197F');
					break;
				case "IsKhmerSymbols":
					set.AddRange('\u19E0','\u19FF');
					break;
				case "IsPhoneticExtensions":
					set.AddRange('\u1D00','\u1D7F');
					break;
				case "IsLatinExtendedAdditional":
					set.AddRange('\u1E00','\u1EFF');
					break;
				case "IsGreekExtended":
					set.AddRange('\u1F00','\u1FFF');
					break;
				case "IsGeneralPunctuation":
					set.AddRange('\u2000','\u206F');
					break;
				case "IsSuperscriptsandSubscripts":
					set.AddRange('\u2070','\u209F');
					break;
				case "IsCurrencySymbols":
					set.AddRange('\u20A0','\u20CF');
					break;
				case "IsCombiningDiacriticalMarksforSymbols":
					set.AddRange('\u20D0','\u20FF');
					break;
                case "IsCombiningMarksforSymbols":
					set.AddRange('\u20D0','\u20FF');
					break;
				case "IsLetterlikeSymbols":
					set.AddRange('\u2100','\u214F');
					break;
				case "IsNumberForms":
					set.AddRange('\u2150','\u218F');
					break;
				case "IsArrows":
					set.AddRange('\u2190','\u21FF');
					break;
				case "IsMathematicalOperators":
					set.AddRange('\u2200','\u22FF');
					break;
				case "IsMiscellaneousTechnical":
					set.AddRange('\u2300','\u23FF');
					break;
				case "IsControlPictures":
					set.AddRange('\u2400','\u243F');
					break;
				case "IsOpticalCharacterRecognition":
					set.AddRange('\u2440','\u245F');
					break;
				case "IsEnclosedAlphanumerics":
					set.AddRange('\u2460','\u24FF');
					break;
				case "IsBoxDrawing":
					set.AddRange('\u2500','\u257F');
					break;
				case "IsBlockElements":
					set.AddRange('\u2580','\u259F');
					break;
				case "IsGeometricShapes":
					set.AddRange('\u25A0','\u25FF');
					break;
				case "IsMiscellaneousSymbols":
					set.AddRange('\u2600','\u26FF');
					break;
				case "IsDingbats":
					set.AddRange('\u2700','\u27BF');
					break;
				case "IsMiscellaneousMathematicalSymbols-A":
					set.AddRange('\u27C0','\u27EF');
					break;
				case "IsSupplementalArrows-A":
					set.AddRange('\u27F0','\u27FF');
					break;
				case "IsBraillePatterns":
					set.AddRange('\u2800','\u28FF');
					break;
				case "IsSupplementalArrows-B":
					set.AddRange('\u2900','\u297F');
					break;
				case "IsMiscellaneousMathematicalSymbols-B":
					set.AddRange('\u2980','\u29FF');
					break;
				case "IsSupplementalMathematicalOperators":
					set.AddRange('\u2A00','\u2AFF');
					break;
				case "IsMiscellaneousSymbolsandArrows":
					set.AddRange('\u2B00','\u2BFF');
					break;
				case "IsCJKRadicalsSupplement":
					set.AddRange('\u2E80','\u2EFF');
					break;
				case "IsKangxiRadicals":
					set.AddRange('\u2F00','\u2FDF');
					break;
				case "IsIdeographicDescriptionCharacters":
					set.AddRange('\u2FF0','\u2FFF');
					break;
				case "IsCJKSymbolsandPunctuation":
					set.AddRange('\u3000','\u303F');
					break;
				case "IsHiragana":
					set.AddRange('\u3040','\u309F');
					break;
				case "IsKatakana":
					set.AddRange('\u30A0','\u30FF');
					break;
				case "IsBopomofo":
					set.AddRange('\u3100','\u312F');
					break;
				case "IsHangulCompatibilityJamo":
					set.AddRange('\u3130','\u318F');
					break;
				case "IsKanbun":
					set.AddRange('\u3190','\u319F');
					break;
				case "IsBopomofoExtended":
					set.AddRange('\u31A0','\u31BF');
					break;
				case "IsKatakanaPhoneticExtensions":
					set.AddRange('\u31F0','\u31FF');
					break;
				case "IsEnclosedCJKLettersandMonths":
					set.AddRange('\u3200','\u32FF');
					break;
				case "IsCJKCompatibility":
					set.AddRange('\u3300','\u33FF');
					break;
				case "IsCJKUnifiedIdeographsExtensionA":
					set.AddRange('\u3400','\u4DBF');
					break;
				case "IsYijingHexagramSymbols":
					set.AddRange('\u4DC0','\u4DFF');
					break;
				case "IsCJKUnifiedIdeographs":
					set.AddRange('\u4E00','\u9FFF');
					break;
				case "IsYiSyllables":
					set.AddRange('\uA000','\uA48F');
					break;
				case "IsYiRadicals":
					set.AddRange('\uA490','\uA4CF');
					break;
				case "IsHangulSyllables":
					set.AddRange('\uAC00','\uD7AF');
					break;
				case "IsHighSurrogates":
					set.AddRange('\uD800','\uDB7F');
					break;
				case "IsHighPrivateUseSurrogates":
					set.AddRange('\uDB80','\uDBFF');
					break;
				case "IsLowSurrogates":
					set.AddRange('\uDC00','\uDFFF');
					break;
				case "IsPrivateUse or IsPrivateUseArea":
					set.AddRange('\uE000','\uF8FF');
					break;
				case "IsCJKCompatibilityIdeographs":
					set.AddRange('\uF900','\uFAFF');
					break;
				case "IsAlphabeticPresentationForms":
					set.AddRange('\uFB00','\uFB4F');
					break;
				case "IsArabicPresentationForms-A":
					set.AddRange('\uFB50','\uFDFF');
					break;
				case "IsVariationSelectors":
					set.AddRange('\uFE00','\uFE0F');
					break;
				case "IsCombiningHalfMarks":
					set.AddRange('\uFE20','\uFE2F');
					break;
				case "IsCJKCompatibilityForms":
					set.AddRange('\uFE30','\uFE4F');
					break;
				case "IsSmallFormVariants":
					set.AddRange('\uFE50','\uFE6F');
					break;
				case "IsArabicPresentationForms-B":
					set.AddRange('\uFE70','\uFEFF');
					break;
				case "IsHalfwidthandFullwidthForms":
					set.AddRange('\uFF00','\uFFEF');
					break;
				case "IsSpecials":
					set.AddRange('\uFFF0','\uFFFF');
					break;
                default:
                    throw new InvalidOperationException(string.Format(
                        "{0} is not a supported or recognized unicode named block or category name.",
                        categoryName));
            }
            return set;
        }

        #endregion //AddCategory

        #region Utilities

        #region AddCategoryLu

        private static void AddCategoryLu(CharacterSet set)
        {
            set
            .AddRange('\u0041', '\u005a')
            .AddRange('\u00c0', '\u00d6')
            .AddRange('\u00d8', '\u00de')
            .AddRange('\u0189', '\u018b')
            .AddRange('\u018e', '\u0191')
            .AddRange('\u0196', '\u0198')
            .AddRange('\u01b1', '\u01b3')
            .AddRange('\u01f6', '\u01f8')
            .AddRange('\u0243', '\u0246')
            .AddRange('\u0388', '\u038a')
            .AddRange('\u0391', '\u03a1')
            .AddRange('\u03a3', '\u03ab')
            .AddRange('\u03d2', '\u03d4')
            .AddRange('\u03fd', '\u042f')
            .AddRange('\u0531', '\u0556')
            .AddRange('\u10a0', '\u10c5')
            .AddRange('\u1f08', '\u1f0f')
            .AddRange('\u1f18', '\u1f1d')
            .AddRange('\u1f28', '\u1f2f')
            .AddRange('\u1f38', '\u1f3f')
            .AddRange('\u1f48', '\u1f4d')
            .AddRange('\u1f68', '\u1f6f')
            .AddRange('\u1fb8', '\u1fbb')
            .AddRange('\u1fc8', '\u1fcb')
            .AddRange('\u1fd8', '\u1fdb')
            .AddRange('\u1fe8', '\u1fec')
            .AddRange('\u1ff8', '\u1ffb')
            .AddRange('\u210b', '\u210d')
            .AddRange('\u2110', '\u2112')
            .AddRange('\u2119', '\u211d')
            .AddRange('\u212a', '\u212d')
            .AddRange('\u2130', '\u2133')
            .AddRange('\u2c00', '\u2c2e')
            .AddRange('\u2c62', '\u2c64')
            .AddRange('\uff21', '\uff3a')
            .AddCharacter('\u0100')
            .AddCharacter('\u0102')
            .AddCharacter('\u0104')
            .AddCharacter('\u0106')
            .AddCharacter('\u0108')
            .AddCharacter('\u010a')
            .AddCharacter('\u010c')
            .AddCharacter('\u010e')
            .AddCharacter('\u0110')
            .AddCharacter('\u0112')
            .AddCharacter('\u0114')
            .AddCharacter('\u0116')
            .AddCharacter('\u0118')
            .AddCharacter('\u011a')
            .AddCharacter('\u011c')
            .AddCharacter('\u011e')
            .AddCharacter('\u0120')
            .AddCharacter('\u0122')
            .AddCharacter('\u0124')
            .AddCharacter('\u0126')
            .AddCharacter('\u0128')
            .AddCharacter('\u012a')
            .AddCharacter('\u012c')
            .AddCharacter('\u012e')
            .AddCharacter('\u0130')
            .AddCharacter('\u0132')
            .AddCharacter('\u0134')
            .AddCharacter('\u0136')
            .AddCharacter('\u0139')
            .AddCharacter('\u013b')
            .AddCharacter('\u013d')
            .AddCharacter('\u013f')
            .AddCharacter('\u0141')
            .AddCharacter('\u0143')
            .AddCharacter('\u0145')
            .AddCharacter('\u0147')
            .AddCharacter('\u014a')
            .AddCharacter('\u014c')
            .AddCharacter('\u014e')
            .AddCharacter('\u0150')
            .AddCharacter('\u0152')
            .AddCharacter('\u0154')
            .AddCharacter('\u0156')
            .AddCharacter('\u0158')
            .AddCharacter('\u015a')
            .AddCharacter('\u015c')
            .AddCharacter('\u015e')
            .AddCharacter('\u0160')
            .AddCharacter('\u0162')
            .AddCharacter('\u0164')
            .AddCharacter('\u0166')
            .AddCharacter('\u0168')
            .AddCharacter('\u016a')
            .AddCharacter('\u016c')
            .AddCharacter('\u016e')
            .AddCharacter('\u0170')
            .AddCharacter('\u0172')
            .AddCharacter('\u0174')
            .AddCharacter('\u0176')
            .AddCharacter('\u0178')
            .AddCharacter('\u0179')
            .AddCharacter('\u017b')
            .AddCharacter('\u017d')
            .AddCharacter('\u0181')
            .AddCharacter('\u0182')
            .AddCharacter('\u0184')
            .AddCharacter('\u0186')
            .AddCharacter('\u0187')
            .AddCharacter('\u0193')
            .AddCharacter('\u0194')
            .AddCharacter('\u019c')
            .AddCharacter('\u019d')
            .AddCharacter('\u019f')
            .AddCharacter('\u01a0')
            .AddCharacter('\u01a2')
            .AddCharacter('\u01a4')
            .AddCharacter('\u01a6')
            .AddCharacter('\u01a7')
            .AddCharacter('\u01a9')
            .AddCharacter('\u01ac')
            .AddCharacter('\u01ae')
            .AddCharacter('\u01af')
            .AddCharacter('\u01b5')
            .AddCharacter('\u01b7')
            .AddCharacter('\u01b8')
            .AddCharacter('\u01bc')
            .AddCharacter('\u01c4')
            .AddCharacter('\u01c7')
            .AddCharacter('\u01ca')
            .AddCharacter('\u01cd')
            .AddCharacter('\u01cf')
            .AddCharacter('\u01d1')
            .AddCharacter('\u01d3')
            .AddCharacter('\u01d5')
            .AddCharacter('\u01d7')
            .AddCharacter('\u01d9')
            .AddCharacter('\u01db')
            .AddCharacter('\u01de')
            .AddCharacter('\u01e0')
            .AddCharacter('\u01e2')
            .AddCharacter('\u01e4')
            .AddCharacter('\u01e6')
            .AddCharacter('\u01e8')
            .AddCharacter('\u01ea')
            .AddCharacter('\u01ec')
            .AddCharacter('\u01ee')
            .AddCharacter('\u01f1')
            .AddCharacter('\u01f4')
            .AddCharacter('\u01fa')
            .AddCharacter('\u01fc')
            .AddCharacter('\u01fe')
            .AddCharacter('\u0200')
            .AddCharacter('\u0202')
            .AddCharacter('\u0204')
            .AddCharacter('\u0206')
            .AddCharacter('\u0208')
            .AddCharacter('\u020a')
            .AddCharacter('\u020c')
            .AddCharacter('\u020e')
            .AddCharacter('\u0210')
            .AddCharacter('\u0212')
            .AddCharacter('\u0214')
            .AddCharacter('\u0216')
            .AddCharacter('\u0218')
            .AddCharacter('\u021a')
            .AddCharacter('\u021c')
            .AddCharacter('\u021e')
            .AddCharacter('\u0220')
            .AddCharacter('\u0222')
            .AddCharacter('\u0224')
            .AddCharacter('\u0226')
            .AddCharacter('\u0228')
            .AddCharacter('\u022a')
            .AddCharacter('\u022c')
            .AddCharacter('\u022e')
            .AddCharacter('\u0230')
            .AddCharacter('\u0232')
            .AddCharacter('\u023a')
            .AddCharacter('\u023b')
            .AddCharacter('\u023d')
            .AddCharacter('\u023e')
            .AddCharacter('\u0241')
            .AddCharacter('\u0248')
            .AddCharacter('\u024a')
            .AddCharacter('\u024c')
            .AddCharacter('\u024e')
            .AddCharacter('\u0386')
            .AddCharacter('\u038c')
            .AddCharacter('\u038e')
            .AddCharacter('\u038f')
            .AddCharacter('\u03d8')
            .AddCharacter('\u03da')
            .AddCharacter('\u03dc')
            .AddCharacter('\u03de')
            .AddCharacter('\u03e0')
            .AddCharacter('\u03e2')
            .AddCharacter('\u03e4')
            .AddCharacter('\u03e6')
            .AddCharacter('\u03e8')
            .AddCharacter('\u03ea')
            .AddCharacter('\u03ec')
            .AddCharacter('\u03ee')
            .AddCharacter('\u03f4')
            .AddCharacter('\u03f7')
            .AddCharacter('\u03f9')
            .AddCharacter('\u03fa')
            .AddCharacter('\u0460')
            .AddCharacter('\u0462')
            .AddCharacter('\u0464')
            .AddCharacter('\u0466')
            .AddCharacter('\u0468')
            .AddCharacter('\u046a')
            .AddCharacter('\u046c')
            .AddCharacter('\u046e')
            .AddCharacter('\u0470')
            .AddCharacter('\u0472')
            .AddCharacter('\u0474')
            .AddCharacter('\u0476')
            .AddCharacter('\u0478')
            .AddCharacter('\u047a')
            .AddCharacter('\u047c')
            .AddCharacter('\u047e')
            .AddCharacter('\u0480')
            .AddCharacter('\u048a')
            .AddCharacter('\u048c')
            .AddCharacter('\u048e')
            .AddCharacter('\u0490')
            .AddCharacter('\u0492')
            .AddCharacter('\u0494')
            .AddCharacter('\u0496')
            .AddCharacter('\u0498')
            .AddCharacter('\u049a')
            .AddCharacter('\u049c')
            .AddCharacter('\u049e')
            .AddCharacter('\u04a0')
            .AddCharacter('\u04a2')
            .AddCharacter('\u04a4')
            .AddCharacter('\u04a6')
            .AddCharacter('\u04a8')
            .AddCharacter('\u04aa')
            .AddCharacter('\u04ac')
            .AddCharacter('\u04ae')
            .AddCharacter('\u04b0')
            .AddCharacter('\u04b2')
            .AddCharacter('\u04b4')
            .AddCharacter('\u04b6')
            .AddCharacter('\u04b8')
            .AddCharacter('\u04ba')
            .AddCharacter('\u04bc')
            .AddCharacter('\u04be')
            .AddCharacter('\u04c0')
            .AddCharacter('\u04c1')
            .AddCharacter('\u04c3')
            .AddCharacter('\u04c5')
            .AddCharacter('\u04c7')
            .AddCharacter('\u04c9')
            .AddCharacter('\u04cb')
            .AddCharacter('\u04cd')
            .AddCharacter('\u04d0')
            .AddCharacter('\u04d2')
            .AddCharacter('\u04d4')
            .AddCharacter('\u04d6')
            .AddCharacter('\u04d8')
            .AddCharacter('\u04da')
            .AddCharacter('\u04dc')
            .AddCharacter('\u04de')
            .AddCharacter('\u04e0')
            .AddCharacter('\u04e2')
            .AddCharacter('\u04e4')
            .AddCharacter('\u04e6')
            .AddCharacter('\u04e8')
            .AddCharacter('\u04ea')
            .AddCharacter('\u04ec')
            .AddCharacter('\u04ee')
            .AddCharacter('\u04f0')
            .AddCharacter('\u04f2')
            .AddCharacter('\u04f4')
            .AddCharacter('\u04f6')
            .AddCharacter('\u04f8')
            .AddCharacter('\u04fa')
            .AddCharacter('\u04fc')
            .AddCharacter('\u04fe')
            .AddCharacter('\u0500')
            .AddCharacter('\u0502')
            .AddCharacter('\u0504')
            .AddCharacter('\u0506')
            .AddCharacter('\u0508')
            .AddCharacter('\u050a')
            .AddCharacter('\u050c')
            .AddCharacter('\u050e')
            .AddCharacter('\u0510')
            .AddCharacter('\u0512')
            .AddCharacter('\u1e00')
            .AddCharacter('\u1e02')
            .AddCharacter('\u1e04')
            .AddCharacter('\u1e06')
            .AddCharacter('\u1e08')
            .AddCharacter('\u1e0a')
            .AddCharacter('\u1e0c')
            .AddCharacter('\u1e0e')
            .AddCharacter('\u1e10')
            .AddCharacter('\u1e12')
            .AddCharacter('\u1e14')
            .AddCharacter('\u1e16')
            .AddCharacter('\u1e18')
            .AddCharacter('\u1e1a')
            .AddCharacter('\u1e1c')
            .AddCharacter('\u1e1e')
            .AddCharacter('\u1e20')
            .AddCharacter('\u1e22')
            .AddCharacter('\u1e24')
            .AddCharacter('\u1e26')
            .AddCharacter('\u1e28')
            .AddCharacter('\u1e2a')
            .AddCharacter('\u1e2c')
            .AddCharacter('\u1e2e')
            .AddCharacter('\u1e30')
            .AddCharacter('\u1e32')
            .AddCharacter('\u1e34')
            .AddCharacter('\u1e36')
            .AddCharacter('\u1e38')
            .AddCharacter('\u1e3a')
            .AddCharacter('\u1e3c')
            .AddCharacter('\u1e3e')
            .AddCharacter('\u1e40')
            .AddCharacter('\u1e42')
            .AddCharacter('\u1e44')
            .AddCharacter('\u1e46')
            .AddCharacter('\u1e48')
            .AddCharacter('\u1e4a')
            .AddCharacter('\u1e4c')
            .AddCharacter('\u1e4e')
            .AddCharacter('\u1e50')
            .AddCharacter('\u1e52')
            .AddCharacter('\u1e54')
            .AddCharacter('\u1e56')
            .AddCharacter('\u1e58')
            .AddCharacter('\u1e5a')
            .AddCharacter('\u1e5c')
            .AddCharacter('\u1e5e')
            .AddCharacter('\u1e60')
            .AddCharacter('\u1e62')
            .AddCharacter('\u1e64')
            .AddCharacter('\u1e66')
            .AddCharacter('\u1e68')
            .AddCharacter('\u1e6a')
            .AddCharacter('\u1e6c')
            .AddCharacter('\u1e6e')
            .AddCharacter('\u1e70')
            .AddCharacter('\u1e72')
            .AddCharacter('\u1e74')
            .AddCharacter('\u1e76')
            .AddCharacter('\u1e78')
            .AddCharacter('\u1e7a')
            .AddCharacter('\u1e7c')
            .AddCharacter('\u1e7e')
            .AddCharacter('\u1e80')
            .AddCharacter('\u1e82')
            .AddCharacter('\u1e84')
            .AddCharacter('\u1e86')
            .AddCharacter('\u1e88')
            .AddCharacter('\u1e8a')
            .AddCharacter('\u1e8c')
            .AddCharacter('\u1e8e')
            .AddCharacter('\u1e90')
            .AddCharacter('\u1e92')
            .AddCharacter('\u1e94')
            .AddCharacter('\u1ea0')
            .AddCharacter('\u1ea2')
            .AddCharacter('\u1ea4')
            .AddCharacter('\u1ea6')
            .AddCharacter('\u1ea8')
            .AddCharacter('\u1eaa')
            .AddCharacter('\u1eac')
            .AddCharacter('\u1eae')
            .AddCharacter('\u1eb0')
            .AddCharacter('\u1eb2')
            .AddCharacter('\u1eb4')
            .AddCharacter('\u1eb6')
            .AddCharacter('\u1eb8')
            .AddCharacter('\u1eba')
            .AddCharacter('\u1ebc')
            .AddCharacter('\u1ebe')
            .AddCharacter('\u1ec0')
            .AddCharacter('\u1ec2')
            .AddCharacter('\u1ec4')
            .AddCharacter('\u1ec6')
            .AddCharacter('\u1ec8')
            .AddCharacter('\u1eca')
            .AddCharacter('\u1ecc')
            .AddCharacter('\u1ece')
            .AddCharacter('\u1ed0')
            .AddCharacter('\u1ed2')
            .AddCharacter('\u1ed4')
            .AddCharacter('\u1ed6')
            .AddCharacter('\u1ed8')
            .AddCharacter('\u1eda')
            .AddCharacter('\u1edc')
            .AddCharacter('\u1ede')
            .AddCharacter('\u1ee0')
            .AddCharacter('\u1ee2')
            .AddCharacter('\u1ee4')
            .AddCharacter('\u1ee6')
            .AddCharacter('\u1ee8')
            .AddCharacter('\u1eea')
            .AddCharacter('\u1eec')
            .AddCharacter('\u1eee')
            .AddCharacter('\u1ef0')
            .AddCharacter('\u1ef2')
            .AddCharacter('\u1ef4')
            .AddCharacter('\u1ef6')
            .AddCharacter('\u1ef8')
            .AddCharacter('\u1f59')
            .AddCharacter('\u1f5b')
            .AddCharacter('\u1f5d')
            .AddCharacter('\u1f5f')
            .AddCharacter('\u2102')
            .AddCharacter('\u2107')
            .AddCharacter('\u2115')
            .AddCharacter('\u2124')
            .AddCharacter('\u2126')
            .AddCharacter('\u2128')
            .AddCharacter('\u213e')
            .AddCharacter('\u213f')
            .AddCharacter('\u2145')
            .AddCharacter('\u2183')
            .AddCharacter('\u2c60')
            .AddCharacter('\u2c67')
            .AddCharacter('\u2c69')
            .AddCharacter('\u2c6b')
            .AddCharacter('\u2c75')
            .AddCharacter('\u2c80')
            .AddCharacter('\u2c82')
            .AddCharacter('\u2c84')
            .AddCharacter('\u2c86')
            .AddCharacter('\u2c88')
            .AddCharacter('\u2c8a')
            .AddCharacter('\u2c8c')
            .AddCharacter('\u2c8e')
            .AddCharacter('\u2c90')
            .AddCharacter('\u2c92')
            .AddCharacter('\u2c94')
            .AddCharacter('\u2c96')
            .AddCharacter('\u2c98')
            .AddCharacter('\u2c9a')
            .AddCharacter('\u2c9c')
            .AddCharacter('\u2c9e')
            .AddCharacter('\u2ca0')
            .AddCharacter('\u2ca2')
            .AddCharacter('\u2ca4')
            .AddCharacter('\u2ca6')
            .AddCharacter('\u2ca8')
            .AddCharacter('\u2caa')
            .AddCharacter('\u2cac')
            .AddCharacter('\u2cae')
            .AddCharacter('\u2cb0')
            .AddCharacter('\u2cb2')
            .AddCharacter('\u2cb4')
            .AddCharacter('\u2cb6')
            .AddCharacter('\u2cb8')
            .AddCharacter('\u2cba')
            .AddCharacter('\u2cbc')
            .AddCharacter('\u2cbe')
            .AddCharacter('\u2cc0')
            .AddCharacter('\u2cc2')
            .AddCharacter('\u2cc4')
            .AddCharacter('\u2cc6')
            .AddCharacter('\u2cc8')
            .AddCharacter('\u2cca')
            .AddCharacter('\u2ccc')
            .AddCharacter('\u2cce')
            .AddCharacter('\u2cd0')
            .AddCharacter('\u2cd2')
            .AddCharacter('\u2cd4')
            .AddCharacter('\u2cd6')
            .AddCharacter('\u2cd8')
            .AddCharacter('\u2cda')
            .AddCharacter('\u2cdc')
            .AddCharacter('\u2cde')
            .AddCharacter('\u2ce0')
            .AddCharacter('\u2ce2');
        }

        #endregion //AddCategoryLu

        #region AddCategoryLl

        private static void AddCategoryLl(CharacterSet set)
        {
            set
            .AddRange('\u0061', '\u007a')
            .AddRange('\u00df', '\u00f6')
            .AddRange('\u00f8', '\u00ff')
            .AddRange('\u017e', '\u0180')
            .AddRange('\u0199', '\u019b')
            .AddRange('\u01bd', '\u01bf')
            .AddRange('\u0233', '\u0239')
            .AddRange('\u024f', '\u0293')
            .AddRange('\u0295', '\u02af')
            .AddRange('\u037b', '\u037d')
            .AddRange('\u03ac', '\u03ce')
            .AddRange('\u03d5', '\u03d7')
            .AddRange('\u03ef', '\u03f3')
            .AddRange('\u0430', '\u045f')
            .AddRange('\u0561', '\u0587')
            .AddRange('\u1d00', '\u1d2b')
            .AddRange('\u1d62', '\u1d77')
            .AddRange('\u1d79', '\u1d9a')
            .AddRange('\u1e95', '\u1e9b')
            .AddRange('\u1f00', '\u1f07')
            .AddRange('\u1f10', '\u1f15')
            .AddRange('\u1f20', '\u1f27')
            .AddRange('\u1f30', '\u1f37')
            .AddRange('\u1f40', '\u1f45')
            .AddRange('\u1f50', '\u1f57')
            .AddRange('\u1f60', '\u1f67')
            .AddRange('\u1f70', '\u1f7d')
            .AddRange('\u1f80', '\u1f87')
            .AddRange('\u1f90', '\u1f97')
            .AddRange('\u1fa0', '\u1fa7')
            .AddRange('\u1fb0', '\u1fb4')
            .AddRange('\u1fc2', '\u1fc4')
            .AddRange('\u1fd0', '\u1fd3')
            .AddRange('\u1fe0', '\u1fe7')
            .AddRange('\u1ff2', '\u1ff4')
            .AddRange('\u2146', '\u2149')
            .AddRange('\u2c30', '\u2c5e')
            .AddRange('\u2d00', '\u2d25')
            .AddRange('\ufb00', '\ufb06')
            .AddRange('\ufb13', '\ufb17')
            .AddRange('\uff41', '\uff5a')
            .AddCharacter('\u00aa')
            .AddCharacter('\u00b5')
            .AddCharacter('\u00ba')
            .AddCharacter('\u0101')
            .AddCharacter('\u0103')
            .AddCharacter('\u0105')
            .AddCharacter('\u0107')
            .AddCharacter('\u0109')
            .AddCharacter('\u010b')
            .AddCharacter('\u010d')
            .AddCharacter('\u010f')
            .AddCharacter('\u0111')
            .AddCharacter('\u0113')
            .AddCharacter('\u0115')
            .AddCharacter('\u0117')
            .AddCharacter('\u0119')
            .AddCharacter('\u011b')
            .AddCharacter('\u011d')
            .AddCharacter('\u011f')
            .AddCharacter('\u0121')
            .AddCharacter('\u0123')
            .AddCharacter('\u0125')
            .AddCharacter('\u0127')
            .AddCharacter('\u0129')
            .AddCharacter('\u012b')
            .AddCharacter('\u012d')
            .AddCharacter('\u012f')
            .AddCharacter('\u0131')
            .AddCharacter('\u0133')
            .AddCharacter('\u0135')
            .AddCharacter('\u0137')
            .AddCharacter('\u0138')
            .AddCharacter('\u013a')
            .AddCharacter('\u013c')
            .AddCharacter('\u013e')
            .AddCharacter('\u0140')
            .AddCharacter('\u0142')
            .AddCharacter('\u0144')
            .AddCharacter('\u0146')
            .AddCharacter('\u0148')
            .AddCharacter('\u0149')
            .AddCharacter('\u014b')
            .AddCharacter('\u014d')
            .AddCharacter('\u014f')
            .AddCharacter('\u0151')
            .AddCharacter('\u0153')
            .AddCharacter('\u0155')
            .AddCharacter('\u0157')
            .AddCharacter('\u0159')
            .AddCharacter('\u015b')
            .AddCharacter('\u015d')
            .AddCharacter('\u015f')
            .AddCharacter('\u0161')
            .AddCharacter('\u0163')
            .AddCharacter('\u0165')
            .AddCharacter('\u0167')
            .AddCharacter('\u0169')
            .AddCharacter('\u016b')
            .AddCharacter('\u016d')
            .AddCharacter('\u016f')
            .AddCharacter('\u0171')
            .AddCharacter('\u0173')
            .AddCharacter('\u0175')
            .AddCharacter('\u0177')
            .AddCharacter('\u017a')
            .AddCharacter('\u017c')
            .AddCharacter('\u0183')
            .AddCharacter('\u0185')
            .AddCharacter('\u0188')
            .AddCharacter('\u018c')
            .AddCharacter('\u018d')
            .AddCharacter('\u0192')
            .AddCharacter('\u0195')
            .AddCharacter('\u019e')
            .AddCharacter('\u01a1')
            .AddCharacter('\u01a3')
            .AddCharacter('\u01a5')
            .AddCharacter('\u01a8')
            .AddCharacter('\u01aa')
            .AddCharacter('\u01ab')
            .AddCharacter('\u01ad')
            .AddCharacter('\u01b0')
            .AddCharacter('\u01b4')
            .AddCharacter('\u01b6')
            .AddCharacter('\u01b9')
            .AddCharacter('\u01ba')
            .AddCharacter('\u01c6')
            .AddCharacter('\u01c9')
            .AddCharacter('\u01cc')
            .AddCharacter('\u01ce')
            .AddCharacter('\u01d0')
            .AddCharacter('\u01d2')
            .AddCharacter('\u01d4')
            .AddCharacter('\u01d6')
            .AddCharacter('\u01d8')
            .AddCharacter('\u01da')
            .AddCharacter('\u01dc')
            .AddCharacter('\u01dd')
            .AddCharacter('\u01df')
            .AddCharacter('\u01e1')
            .AddCharacter('\u01e3')
            .AddCharacter('\u01e5')
            .AddCharacter('\u01e7')
            .AddCharacter('\u01e9')
            .AddCharacter('\u01eb')
            .AddCharacter('\u01ed')
            .AddCharacter('\u01ef')
            .AddCharacter('\u01f0')
            .AddCharacter('\u01f3')
            .AddCharacter('\u01f5')
            .AddCharacter('\u01f9')
            .AddCharacter('\u01fb')
            .AddCharacter('\u01fd')
            .AddCharacter('\u01ff')
            .AddCharacter('\u0201')
            .AddCharacter('\u0203')
            .AddCharacter('\u0205')
            .AddCharacter('\u0207')
            .AddCharacter('\u0209')
            .AddCharacter('\u020b')
            .AddCharacter('\u020d')
            .AddCharacter('\u020f')
            .AddCharacter('\u0211')
            .AddCharacter('\u0213')
            .AddCharacter('\u0215')
            .AddCharacter('\u0217')
            .AddCharacter('\u0219')
            .AddCharacter('\u021b')
            .AddCharacter('\u021d')
            .AddCharacter('\u021f')
            .AddCharacter('\u0221')
            .AddCharacter('\u0223')
            .AddCharacter('\u0225')
            .AddCharacter('\u0227')
            .AddCharacter('\u0229')
            .AddCharacter('\u022b')
            .AddCharacter('\u022d')
            .AddCharacter('\u022f')
            .AddCharacter('\u0231')
            .AddCharacter('\u023c')
            .AddCharacter('\u023f')
            .AddCharacter('\u0240')
            .AddCharacter('\u0242')
            .AddCharacter('\u0247')
            .AddCharacter('\u0249')
            .AddCharacter('\u024b')
            .AddCharacter('\u024d')
            .AddCharacter('\u0390')
            .AddCharacter('\u03d0')
            .AddCharacter('\u03d1')
            .AddCharacter('\u03d9')
            .AddCharacter('\u03db')
            .AddCharacter('\u03dd')
            .AddCharacter('\u03df')
            .AddCharacter('\u03e1')
            .AddCharacter('\u03e3')
            .AddCharacter('\u03e5')
            .AddCharacter('\u03e7')
            .AddCharacter('\u03e9')
            .AddCharacter('\u03eb')
            .AddCharacter('\u03ed')
            .AddCharacter('\u03f5')
            .AddCharacter('\u03f8')
            .AddCharacter('\u03fb')
            .AddCharacter('\u03fc')
            .AddCharacter('\u0461')
            .AddCharacter('\u0463')
            .AddCharacter('\u0465')
            .AddCharacter('\u0467')
            .AddCharacter('\u0469')
            .AddCharacter('\u046b')
            .AddCharacter('\u046d')
            .AddCharacter('\u046f')
            .AddCharacter('\u0471')
            .AddCharacter('\u0473')
            .AddCharacter('\u0475')
            .AddCharacter('\u0477')
            .AddCharacter('\u0479')
            .AddCharacter('\u047b')
            .AddCharacter('\u047d')
            .AddCharacter('\u047f')
            .AddCharacter('\u0481')
            .AddCharacter('\u048b')
            .AddCharacter('\u048d')
            .AddCharacter('\u048f')
            .AddCharacter('\u0491')
            .AddCharacter('\u0493')
            .AddCharacter('\u0495')
            .AddCharacter('\u0497')
            .AddCharacter('\u0499')
            .AddCharacter('\u049b')
            .AddCharacter('\u049d')
            .AddCharacter('\u049f')
            .AddCharacter('\u04a1')
            .AddCharacter('\u04a3')
            .AddCharacter('\u04a5')
            .AddCharacter('\u04a7')
            .AddCharacter('\u04a9')
            .AddCharacter('\u04ab')
            .AddCharacter('\u04ad')
            .AddCharacter('\u04af')
            .AddCharacter('\u04b1')
            .AddCharacter('\u04b3')
            .AddCharacter('\u04b5')
            .AddCharacter('\u04b7')
            .AddCharacter('\u04b9')
            .AddCharacter('\u04bb')
            .AddCharacter('\u04bd')
            .AddCharacter('\u04bf')
            .AddCharacter('\u04c2')
            .AddCharacter('\u04c4')
            .AddCharacter('\u04c6')
            .AddCharacter('\u04c8')
            .AddCharacter('\u04ca')
            .AddCharacter('\u04cc')
            .AddCharacter('\u04ce')
            .AddCharacter('\u04cf')
            .AddCharacter('\u04d1')
            .AddCharacter('\u04d3')
            .AddCharacter('\u04d5')
            .AddCharacter('\u04d7')
            .AddCharacter('\u04d9')
            .AddCharacter('\u04db')
            .AddCharacter('\u04dd')
            .AddCharacter('\u04df')
            .AddCharacter('\u04e1')
            .AddCharacter('\u04e3')
            .AddCharacter('\u04e5')
            .AddCharacter('\u04e7')
            .AddCharacter('\u04e9')
            .AddCharacter('\u04eb')
            .AddCharacter('\u04ed')
            .AddCharacter('\u04ef')
            .AddCharacter('\u04f1')
            .AddCharacter('\u04f3')
            .AddCharacter('\u04f5')
            .AddCharacter('\u04f7')
            .AddCharacter('\u04f9')
            .AddCharacter('\u04fb')
            .AddCharacter('\u04fd')
            .AddCharacter('\u04ff')
            .AddCharacter('\u0501')
            .AddCharacter('\u0503')
            .AddCharacter('\u0505')
            .AddCharacter('\u0507')
            .AddCharacter('\u0509')
            .AddCharacter('\u050b')
            .AddCharacter('\u050d')
            .AddCharacter('\u050f')
            .AddCharacter('\u0511')
            .AddCharacter('\u0513')
            .AddCharacter('\u1e01')
            .AddCharacter('\u1e03')
            .AddCharacter('\u1e05')
            .AddCharacter('\u1e07')
            .AddCharacter('\u1e09')
            .AddCharacter('\u1e0b')
            .AddCharacter('\u1e0d')
            .AddCharacter('\u1e0f')
            .AddCharacter('\u1e11')
            .AddCharacter('\u1e13')
            .AddCharacter('\u1e15')
            .AddCharacter('\u1e17')
            .AddCharacter('\u1e19')
            .AddCharacter('\u1e1b')
            .AddCharacter('\u1e1d')
            .AddCharacter('\u1e1f')
            .AddCharacter('\u1e21')
            .AddCharacter('\u1e23')
            .AddCharacter('\u1e25')
            .AddCharacter('\u1e27')
            .AddCharacter('\u1e29')
            .AddCharacter('\u1e2b')
            .AddCharacter('\u1e2d')
            .AddCharacter('\u1e2f')
            .AddCharacter('\u1e31')
            .AddCharacter('\u1e33')
            .AddCharacter('\u1e35')
            .AddCharacter('\u1e37')
            .AddCharacter('\u1e39')
            .AddCharacter('\u1e3b')
            .AddCharacter('\u1e3d')
            .AddCharacter('\u1e3f')
            .AddCharacter('\u1e41')
            .AddCharacter('\u1e43')
            .AddCharacter('\u1e45')
            .AddCharacter('\u1e47')
            .AddCharacter('\u1e49')
            .AddCharacter('\u1e4b')
            .AddCharacter('\u1e4d')
            .AddCharacter('\u1e4f')
            .AddCharacter('\u1e51')
            .AddCharacter('\u1e53')
            .AddCharacter('\u1e55')
            .AddCharacter('\u1e57')
            .AddCharacter('\u1e59')
            .AddCharacter('\u1e5b')
            .AddCharacter('\u1e5d')
            .AddCharacter('\u1e5f')
            .AddCharacter('\u1e61')
            .AddCharacter('\u1e63')
            .AddCharacter('\u1e65')
            .AddCharacter('\u1e67')
            .AddCharacter('\u1e69')
            .AddCharacter('\u1e6b')
            .AddCharacter('\u1e6d')
            .AddCharacter('\u1e6f')
            .AddCharacter('\u1e71')
            .AddCharacter('\u1e73')
            .AddCharacter('\u1e75')
            .AddCharacter('\u1e77')
            .AddCharacter('\u1e79')
            .AddCharacter('\u1e7b')
            .AddCharacter('\u1e7d')
            .AddCharacter('\u1e7f')
            .AddCharacter('\u1e81')
            .AddCharacter('\u1e83')
            .AddCharacter('\u1e85')
            .AddCharacter('\u1e87')
            .AddCharacter('\u1e89')
            .AddCharacter('\u1e8b')
            .AddCharacter('\u1e8d')
            .AddCharacter('\u1e8f')
            .AddCharacter('\u1e91')
            .AddCharacter('\u1e93')
            .AddCharacter('\u1ea1')
            .AddCharacter('\u1ea3')
            .AddCharacter('\u1ea5')
            .AddCharacter('\u1ea7')
            .AddCharacter('\u1ea9')
            .AddCharacter('\u1eab')
            .AddCharacter('\u1ead')
            .AddCharacter('\u1eaf')
            .AddCharacter('\u1eb1')
            .AddCharacter('\u1eb3')
            .AddCharacter('\u1eb5')
            .AddCharacter('\u1eb7')
            .AddCharacter('\u1eb9')
            .AddCharacter('\u1ebb')
            .AddCharacter('\u1ebd')
            .AddCharacter('\u1ebf')
            .AddCharacter('\u1ec1')
            .AddCharacter('\u1ec3')
            .AddCharacter('\u1ec5')
            .AddCharacter('\u1ec7')
            .AddCharacter('\u1ec9')
            .AddCharacter('\u1ecb')
            .AddCharacter('\u1ecd')
            .AddCharacter('\u1ecf')
            .AddCharacter('\u1ed1')
            .AddCharacter('\u1ed3')
            .AddCharacter('\u1ed5')
            .AddCharacter('\u1ed7')
            .AddCharacter('\u1ed9')
            .AddCharacter('\u1edb')
            .AddCharacter('\u1edd')
            .AddCharacter('\u1edf')
            .AddCharacter('\u1ee1')
            .AddCharacter('\u1ee3')
            .AddCharacter('\u1ee5')
            .AddCharacter('\u1ee7')
            .AddCharacter('\u1ee9')
            .AddCharacter('\u1eeb')
            .AddCharacter('\u1eed')
            .AddCharacter('\u1eef')
            .AddCharacter('\u1ef1')
            .AddCharacter('\u1ef3')
            .AddCharacter('\u1ef5')
            .AddCharacter('\u1ef7')
            .AddCharacter('\u1ef9')
            .AddCharacter('\u1fb6')
            .AddCharacter('\u1fb7')
            .AddCharacter('\u1fbe')
            .AddCharacter('\u1fc6')
            .AddCharacter('\u1fc7')
            .AddCharacter('\u1fd6')
            .AddCharacter('\u1fd7')
            .AddCharacter('\u1ff6')
            .AddCharacter('\u1ff7')
            .AddCharacter('\u2071')
            .AddCharacter('\u207f')
            .AddCharacter('\u210a')
            .AddCharacter('\u210e')
            .AddCharacter('\u210f')
            .AddCharacter('\u2113')
            .AddCharacter('\u212f')
            .AddCharacter('\u2134')
            .AddCharacter('\u2139')
            .AddCharacter('\u213c')
            .AddCharacter('\u213d')
            .AddCharacter('\u214e')
            .AddCharacter('\u2184')
            .AddCharacter('\u2c61')
            .AddCharacter('\u2c65')
            .AddCharacter('\u2c66')
            .AddCharacter('\u2c68')
            .AddCharacter('\u2c6a')
            .AddCharacter('\u2c6c')
            .AddCharacter('\u2c74')
            .AddCharacter('\u2c76')
            .AddCharacter('\u2c77')
            .AddCharacter('\u2c81')
            .AddCharacter('\u2c83')
            .AddCharacter('\u2c85')
            .AddCharacter('\u2c87')
            .AddCharacter('\u2c89')
            .AddCharacter('\u2c8b')
            .AddCharacter('\u2c8d')
            .AddCharacter('\u2c8f')
            .AddCharacter('\u2c91')
            .AddCharacter('\u2c93')
            .AddCharacter('\u2c95')
            .AddCharacter('\u2c97')
            .AddCharacter('\u2c99')
            .AddCharacter('\u2c9b')
            .AddCharacter('\u2c9d')
            .AddCharacter('\u2c9f')
            .AddCharacter('\u2ca1')
            .AddCharacter('\u2ca3')
            .AddCharacter('\u2ca5')
            .AddCharacter('\u2ca7')
            .AddCharacter('\u2ca9')
            .AddCharacter('\u2cab')
            .AddCharacter('\u2cad')
            .AddCharacter('\u2caf')
            .AddCharacter('\u2cb1')
            .AddCharacter('\u2cb3')
            .AddCharacter('\u2cb5')
            .AddCharacter('\u2cb7')
            .AddCharacter('\u2cb9')
            .AddCharacter('\u2cbb')
            .AddCharacter('\u2cbd')
            .AddCharacter('\u2cbf')
            .AddCharacter('\u2cc1')
            .AddCharacter('\u2cc3')
            .AddCharacter('\u2cc5')
            .AddCharacter('\u2cc7')
            .AddCharacter('\u2cc9')
            .AddCharacter('\u2ccb')
            .AddCharacter('\u2ccd')
            .AddCharacter('\u2ccf')
            .AddCharacter('\u2cd1')
            .AddCharacter('\u2cd3')
            .AddCharacter('\u2cd5')
            .AddCharacter('\u2cd7')
            .AddCharacter('\u2cd9')
            .AddCharacter('\u2cdb')
            .AddCharacter('\u2cdd')
            .AddCharacter('\u2cdf')
            .AddCharacter('\u2ce1')
            .AddCharacter('\u2ce3')
            .AddCharacter('\u2ce4');
        }

        #endregion //AddCategoryLl

        #region AddCategoryLt

        private static void AddCategoryLt(CharacterSet set)
        {
            set
            .AddRange('\u1f88', '\u1f8f')
            .AddRange('\u1f98', '\u1f9f')
            .AddRange('\u1fa8', '\u1faf')
            .AddCharacter('\u01c5')
            .AddCharacter('\u01c8')
            .AddCharacter('\u01cb')
            .AddCharacter('\u01f2')
            .AddCharacter('\u1fbc')
            .AddCharacter('\u1fcc')
            .AddCharacter('\u1ffc');
        }

        #endregion //AddCategoryLt

        #region AddCategoryLm

        private static void AddCategoryLm(CharacterSet set)
        {
            set
            .AddRange('\u02b0', '\u02c1')
            .AddRange('\u02c6', '\u02d1')
            .AddRange('\u02e0', '\u02e4')
            .AddRange('\u1d2c', '\u1d61')
            .AddRange('\u1d9b', '\u1dbf')
            .AddRange('\u2090', '\u2094')
            .AddRange('\u3031', '\u3035')
            .AddRange('\u30fc', '\u30fe')
            .AddRange('\ua717', '\ua71a')
            .AddCharacter('\u02ee')
            .AddCharacter('\u037a')
            .AddCharacter('\u0559')
            .AddCharacter('\u0640')
            .AddCharacter('\u06e5')
            .AddCharacter('\u06e6')
            .AddCharacter('\u07f4')
            .AddCharacter('\u07f5')
            .AddCharacter('\u07fa')
            .AddCharacter('\u0e46')
            .AddCharacter('\u0ec6')
            .AddCharacter('\u10fc')
            .AddCharacter('\u17d7')
            .AddCharacter('\u1843')
            .AddCharacter('\u1d78')
            .AddCharacter('\u2d6f')
            .AddCharacter('\u3005')
            .AddCharacter('\u303b')
            .AddCharacter('\u309d')
            .AddCharacter('\u309e')
            .AddCharacter('\ua015')
            .AddCharacter('\uff70')
            .AddCharacter('\uff9e')
            .AddCharacter('\uff9f');
        }

        #endregion //AddCategoryLm

        #region AddCategoryLo

        private static void AddCategoryLo(CharacterSet set)
        {
            set
            .AddRange('\u01c0', '\u01c3')
            .AddRange('\u05d0', '\u05ea')
            .AddRange('\u05f0', '\u05f2')
            .AddRange('\u0621', '\u063a')
            .AddRange('\u0641', '\u064a')
            .AddRange('\u0671', '\u06d3')
            .AddRange('\u06fa', '\u06fc')
            .AddRange('\u0712', '\u072f')
            .AddRange('\u074d', '\u076d')
            .AddRange('\u0780', '\u07a5')
            .AddRange('\u07ca', '\u07ea')
            .AddRange('\u0904', '\u0939')
            .AddRange('\u0958', '\u0961')
            .AddRange('\u097b', '\u097f')
            .AddRange('\u0985', '\u098c')
            .AddRange('\u0993', '\u09a8')
            .AddRange('\u09aa', '\u09b0')
            .AddRange('\u09b6', '\u09b9')
            .AddRange('\u09df', '\u09e1')
            .AddRange('\u0a05', '\u0a0a')
            .AddRange('\u0a13', '\u0a28')
            .AddRange('\u0a2a', '\u0a30')
            .AddRange('\u0a59', '\u0a5c')
            .AddRange('\u0a72', '\u0a74')
            .AddRange('\u0a85', '\u0a8d')
            .AddRange('\u0a8f', '\u0a91')
            .AddRange('\u0a93', '\u0aa8')
            .AddRange('\u0aaa', '\u0ab0')
            .AddRange('\u0ab5', '\u0ab9')
            .AddRange('\u0b05', '\u0b0c')
            .AddRange('\u0b13', '\u0b28')
            .AddRange('\u0b2a', '\u0b30')
            .AddRange('\u0b35', '\u0b39')
            .AddRange('\u0b5f', '\u0b61')
            .AddRange('\u0b85', '\u0b8a')
            .AddRange('\u0b8e', '\u0b90')
            .AddRange('\u0b92', '\u0b95')
            .AddRange('\u0ba8', '\u0baa')
            .AddRange('\u0bae', '\u0bb9')
            .AddRange('\u0c05', '\u0c0c')
            .AddRange('\u0c0e', '\u0c10')
            .AddRange('\u0c12', '\u0c28')
            .AddRange('\u0c2a', '\u0c33')
            .AddRange('\u0c35', '\u0c39')
            .AddRange('\u0c85', '\u0c8c')
            .AddRange('\u0c8e', '\u0c90')
            .AddRange('\u0c92', '\u0ca8')
            .AddRange('\u0caa', '\u0cb3')
            .AddRange('\u0cb5', '\u0cb9')
            .AddRange('\u0d05', '\u0d0c')
            .AddRange('\u0d0e', '\u0d10')
            .AddRange('\u0d12', '\u0d28')
            .AddRange('\u0d2a', '\u0d39')
            .AddRange('\u0d85', '\u0d96')
            .AddRange('\u0d9a', '\u0db1')
            .AddRange('\u0db3', '\u0dbb')
            .AddRange('\u0dc0', '\u0dc6')
            .AddRange('\u0e01', '\u0e30')
            .AddRange('\u0e40', '\u0e45')
            .AddRange('\u0e94', '\u0e97')
            .AddRange('\u0e99', '\u0e9f')
            .AddRange('\u0ea1', '\u0ea3')
            .AddRange('\u0ead', '\u0eb0')
            .AddRange('\u0ec0', '\u0ec4')
            .AddRange('\u0f40', '\u0f47')
            .AddRange('\u0f49', '\u0f6a')
            .AddRange('\u0f88', '\u0f8b')
            .AddRange('\u1000', '\u1021')
            .AddRange('\u1023', '\u1027')
            .AddRange('\u1050', '\u1055')
            .AddRange('\u10d0', '\u10fa')
            .AddRange('\u1100', '\u1159')
            .AddRange('\u115f', '\u11a2')
            .AddRange('\u11a8', '\u11f9')
            .AddRange('\u1200', '\u1248')
            .AddRange('\u124a', '\u124d')
            .AddRange('\u1250', '\u1256')
            .AddRange('\u125a', '\u125d')
            .AddRange('\u1260', '\u1288')
            .AddRange('\u128a', '\u128d')
            .AddRange('\u1290', '\u12b0')
            .AddRange('\u12b2', '\u12b5')
            .AddRange('\u12b8', '\u12be')
            .AddRange('\u12c2', '\u12c5')
            .AddRange('\u12c8', '\u12d6')
            .AddRange('\u12d8', '\u1310')
            .AddRange('\u1312', '\u1315')
            .AddRange('\u1318', '\u135a')
            .AddRange('\u1380', '\u138f')
            .AddRange('\u13a0', '\u13f4')
            .AddRange('\u1401', '\u166c')
            .AddRange('\u166f', '\u1676')
            .AddRange('\u1681', '\u169a')
            .AddRange('\u16a0', '\u16ea')
            .AddRange('\u1700', '\u170c')
            .AddRange('\u170e', '\u1711')
            .AddRange('\u1720', '\u1731')
            .AddRange('\u1740', '\u1751')
            .AddRange('\u1760', '\u176c')
            .AddRange('\u176e', '\u1770')
            .AddRange('\u1780', '\u17b3')
            .AddRange('\u1820', '\u1842')
            .AddRange('\u1844', '\u1877')
            .AddRange('\u1880', '\u18a8')
            .AddRange('\u1900', '\u191c')
            .AddRange('\u1950', '\u196d')
            .AddRange('\u1970', '\u1974')
            .AddRange('\u1980', '\u19a9')
            .AddRange('\u19c1', '\u19c7')
            .AddRange('\u1a00', '\u1a16')
            .AddRange('\u1b05', '\u1b33')
            .AddRange('\u1b45', '\u1b4b')
            .AddRange('\u2135', '\u2138')
            .AddRange('\u2d30', '\u2d65')
            .AddRange('\u2d80', '\u2d96')
            .AddRange('\u2da0', '\u2da6')
            .AddRange('\u2da8', '\u2dae')
            .AddRange('\u2db0', '\u2db6')
            .AddRange('\u2db8', '\u2dbe')
            .AddRange('\u2dc0', '\u2dc6')
            .AddRange('\u2dc8', '\u2dce')
            .AddRange('\u2dd0', '\u2dd6')
            .AddRange('\u2dd8', '\u2dde')
            .AddRange('\u3041', '\u3096')
            .AddRange('\u30a1', '\u30fa')
            .AddRange('\u3105', '\u312c')
            .AddRange('\u3131', '\u318e')
            .AddRange('\u31a0', '\u31b7')
            .AddRange('\u31f0', '\u31ff')
            .AddRange('\u3400', '\u4db5')
            .AddRange('\u4e00', '\u9fbb')
            .AddRange('\ua000', '\ua014')
            .AddRange('\ua016', '\ua48c')
            .AddRange('\ua803', '\ua805')
            .AddRange('\ua807', '\ua80a')
            .AddRange('\ua80c', '\ua822')
            .AddRange('\ua840', '\ua873')
            .AddRange('\uac00', '\ud7a3')
            .AddRange('\uf900', '\ufa2d')
            .AddRange('\ufa30', '\ufa6a')
            .AddRange('\ufa70', '\ufad9')
            .AddRange('\ufb1f', '\ufb28')
            .AddRange('\ufb2a', '\ufb36')
            .AddRange('\ufb38', '\ufb3c')
            .AddRange('\ufb46', '\ufbb1')
            .AddRange('\ufbd3', '\ufd3d')
            .AddRange('\ufd50', '\ufd8f')
            .AddRange('\ufd92', '\ufdc7')
            .AddRange('\ufdf0', '\ufdfb')
            .AddRange('\ufe70', '\ufe74')
            .AddRange('\ufe76', '\ufefc')
            .AddRange('\uff66', '\uff6f')
            .AddRange('\uff71', '\uff9d')
            .AddRange('\uffa0', '\uffbe')
            .AddRange('\uffc2', '\uffc7')
            .AddRange('\uffca', '\uffcf')
            .AddRange('\uffd2', '\uffd7')
            .AddRange('\uffda', '\uffdc')
            .AddCharacter('\u01bb')
            .AddCharacter('\u0294')
            .AddCharacter('\u066e')
            .AddCharacter('\u066f')
            .AddCharacter('\u06d5')
            .AddCharacter('\u06ee')
            .AddCharacter('\u06ef')
            .AddCharacter('\u06ff')
            .AddCharacter('\u0710')
            .AddCharacter('\u07b1')
            .AddCharacter('\u093d')
            .AddCharacter('\u0950')
            .AddCharacter('\u098f')
            .AddCharacter('\u0990')
            .AddCharacter('\u09b2')
            .AddCharacter('\u09bd')
            .AddCharacter('\u09ce')
            .AddCharacter('\u09dc')
            .AddCharacter('\u09dd')
            .AddCharacter('\u09f0')
            .AddCharacter('\u09f1')
            .AddCharacter('\u0a0f')
            .AddCharacter('\u0a10')
            .AddCharacter('\u0a32')
            .AddCharacter('\u0a33')
            .AddCharacter('\u0a35')
            .AddCharacter('\u0a36')
            .AddCharacter('\u0a38')
            .AddCharacter('\u0a39')
            .AddCharacter('\u0a5e')
            .AddCharacter('\u0ab2')
            .AddCharacter('\u0ab3')
            .AddCharacter('\u0abd')
            .AddCharacter('\u0ad0')
            .AddCharacter('\u0ae0')
            .AddCharacter('\u0ae1')
            .AddCharacter('\u0b0f')
            .AddCharacter('\u0b10')
            .AddCharacter('\u0b32')
            .AddCharacter('\u0b33')
            .AddCharacter('\u0b3d')
            .AddCharacter('\u0b5c')
            .AddCharacter('\u0b5d')
            .AddCharacter('\u0b71')
            .AddCharacter('\u0b83')
            .AddCharacter('\u0b99')
            .AddCharacter('\u0b9a')
            .AddCharacter('\u0b9c')
            .AddCharacter('\u0b9e')
            .AddCharacter('\u0b9f')
            .AddCharacter('\u0ba3')
            .AddCharacter('\u0ba4')
            .AddCharacter('\u0c60')
            .AddCharacter('\u0c61')
            .AddCharacter('\u0cbd')
            .AddCharacter('\u0cde')
            .AddCharacter('\u0ce0')
            .AddCharacter('\u0ce1')
            .AddCharacter('\u0d60')
            .AddCharacter('\u0d61')
            .AddCharacter('\u0dbd')
            .AddCharacter('\u0e32')
            .AddCharacter('\u0e33')
            .AddCharacter('\u0e81')
            .AddCharacter('\u0e82')
            .AddCharacter('\u0e84')
            .AddCharacter('\u0e87')
            .AddCharacter('\u0e88')
            .AddCharacter('\u0e8a')
            .AddCharacter('\u0e8d')
            .AddCharacter('\u0ea5')
            .AddCharacter('\u0ea7')
            .AddCharacter('\u0eaa')
            .AddCharacter('\u0eab')
            .AddCharacter('\u0eb2')
            .AddCharacter('\u0eb3')
            .AddCharacter('\u0ebd')
            .AddCharacter('\u0edc')
            .AddCharacter('\u0edd')
            .AddCharacter('\u0f00')
            .AddCharacter('\u1029')
            .AddCharacter('\u102a')
            .AddCharacter('\u1258')
            .AddCharacter('\u12c0')
            .AddCharacter('\u17dc')
            .AddCharacter('\u3006')
            .AddCharacter('\u303c')
            .AddCharacter('\u309f')
            .AddCharacter('\u30ff')
            .AddCharacter('\ua800')
            .AddCharacter('\ua801')
            .AddCharacter('\ufb1d')
            .AddCharacter('\ufb3e')
            .AddCharacter('\ufb40')
            .AddCharacter('\ufb41')
            .AddCharacter('\ufb43')
            .AddCharacter('\ufb44');
        }

        #endregion //AddCategoryLo

        #region AddCategoryL

        private static void AddCategoryL(CharacterSet set)
        {
            AddCategoryLu(set);
            AddCategoryLl(set);
            AddCategoryLt(set);
            AddCategoryLm(set);
            AddCategoryLo(set);
        }

        #endregion //AddCategoryL

        #region AddCategoryMn

        private static void AddCategoryMn(CharacterSet set)
        {
            set
            .AddRange('\u0300', '\u036f')
            .AddRange('\u0483', '\u0486')
            .AddRange('\u0591', '\u05bd')
            .AddRange('\u0610', '\u0615')
            .AddRange('\u064b', '\u065e')
            .AddRange('\u06d6', '\u06dc')
            .AddRange('\u06df', '\u06e4')
            .AddRange('\u06ea', '\u06ed')
            .AddRange('\u0730', '\u074a')
            .AddRange('\u07a6', '\u07b0')
            .AddRange('\u07eb', '\u07f3')
            .AddRange('\u0941', '\u0948')
            .AddRange('\u0951', '\u0954')
            .AddRange('\u09c1', '\u09c4')
            .AddRange('\u0a4b', '\u0a4d')
            .AddRange('\u0ac1', '\u0ac5')
            .AddRange('\u0b41', '\u0b43')
            .AddRange('\u0c3e', '\u0c40')
            .AddRange('\u0c46', '\u0c48')
            .AddRange('\u0c4a', '\u0c4d')
            .AddRange('\u0d41', '\u0d43')
            .AddRange('\u0dd2', '\u0dd4')
            .AddRange('\u0e34', '\u0e3a')
            .AddRange('\u0e47', '\u0e4e')
            .AddRange('\u0eb4', '\u0eb9')
            .AddRange('\u0ec8', '\u0ecd')
            .AddRange('\u0f71', '\u0f7e')
            .AddRange('\u0f80', '\u0f84')
            .AddRange('\u0f90', '\u0f97')
            .AddRange('\u0f99', '\u0fbc')
            .AddRange('\u102d', '\u1030')
            .AddRange('\u1712', '\u1714')
            .AddRange('\u1732', '\u1734')
            .AddRange('\u17b7', '\u17bd')
            .AddRange('\u17c9', '\u17d3')
            .AddRange('\u180b', '\u180d')
            .AddRange('\u1920', '\u1922')
            .AddRange('\u1939', '\u193b')
            .AddRange('\u1b00', '\u1b03')
            .AddRange('\u1b36', '\u1b3a')
            .AddRange('\u1b6b', '\u1b73')
            .AddRange('\u1dc0', '\u1dca')
            .AddRange('\u20d0', '\u20dc')
            .AddRange('\u20e5', '\u20ef')
            .AddRange('\u302a', '\u302f')
            .AddRange('\ufe00', '\ufe0f')
            .AddRange('\ufe20', '\ufe23')
            .AddCharacter('\u05bf')
            .AddCharacter('\u05c1')
            .AddCharacter('\u05c2')
            .AddCharacter('\u05c4')
            .AddCharacter('\u05c5')
            .AddCharacter('\u05c7')
            .AddCharacter('\u0670')
            .AddCharacter('\u06e7')
            .AddCharacter('\u06e8')
            .AddCharacter('\u0711')
            .AddCharacter('\u0901')
            .AddCharacter('\u0902')
            .AddCharacter('\u093c')
            .AddCharacter('\u094d')
            .AddCharacter('\u0962')
            .AddCharacter('\u0963')
            .AddCharacter('\u0981')
            .AddCharacter('\u09bc')
            .AddCharacter('\u09cd')
            .AddCharacter('\u09e2')
            .AddCharacter('\u09e3')
            .AddCharacter('\u0a01')
            .AddCharacter('\u0a02')
            .AddCharacter('\u0a3c')
            .AddCharacter('\u0a41')
            .AddCharacter('\u0a42')
            .AddCharacter('\u0a47')
            .AddCharacter('\u0a48')
            .AddCharacter('\u0a70')
            .AddCharacter('\u0a71')
            .AddCharacter('\u0a81')
            .AddCharacter('\u0a82')
            .AddCharacter('\u0abc')
            .AddCharacter('\u0ac7')
            .AddCharacter('\u0ac8')
            .AddCharacter('\u0acd')
            .AddCharacter('\u0ae2')
            .AddCharacter('\u0ae3')
            .AddCharacter('\u0b01')
            .AddCharacter('\u0b3c')
            .AddCharacter('\u0b3f')
            .AddCharacter('\u0b4d')
            .AddCharacter('\u0b56')
            .AddCharacter('\u0b82')
            .AddCharacter('\u0bc0')
            .AddCharacter('\u0bcd')
            .AddCharacter('\u0c55')
            .AddCharacter('\u0c56')
            .AddCharacter('\u0cbc')
            .AddCharacter('\u0cbf')
            .AddCharacter('\u0cc6')
            .AddCharacter('\u0ccc')
            .AddCharacter('\u0ccd')
            .AddCharacter('\u0ce2')
            .AddCharacter('\u0ce3')
            .AddCharacter('\u0d4d')
            .AddCharacter('\u0dca')
            .AddCharacter('\u0dd6')
            .AddCharacter('\u0e31')
            .AddCharacter('\u0eb1')
            .AddCharacter('\u0ebb')
            .AddCharacter('\u0ebc')
            .AddCharacter('\u0f18')
            .AddCharacter('\u0f19')
            .AddCharacter('\u0f35')
            .AddCharacter('\u0f37')
            .AddCharacter('\u0f39')
            .AddCharacter('\u0f86')
            .AddCharacter('\u0f87')
            .AddCharacter('\u0fc6')
            .AddCharacter('\u1032')
            .AddCharacter('\u1036')
            .AddCharacter('\u1037')
            .AddCharacter('\u1039')
            .AddCharacter('\u1058')
            .AddCharacter('\u1059')
            .AddCharacter('\u135f')
            .AddCharacter('\u1752')
            .AddCharacter('\u1753')
            .AddCharacter('\u1772')
            .AddCharacter('\u1773')
            .AddCharacter('\u17c6')
            .AddCharacter('\u17dd')
            .AddCharacter('\u18a9')
            .AddCharacter('\u1927')
            .AddCharacter('\u1928')
            .AddCharacter('\u1932')
            .AddCharacter('\u1a17')
            .AddCharacter('\u1a18')
            .AddCharacter('\u1b34')
            .AddCharacter('\u1b3c')
            .AddCharacter('\u1b42')
            .AddCharacter('\u1dfe')
            .AddCharacter('\u1dff')
            .AddCharacter('\u20e1')
            .AddCharacter('\u3099')
            .AddCharacter('\u309a')
            .AddCharacter('\ua806')
            .AddCharacter('\ua80b')
            .AddCharacter('\ua825')
            .AddCharacter('\ua826')
            .AddCharacter('\ufb1e');
        }

        #endregion //AddCategoryMn

        #region AddCategoryMc

        private static void AddCategoryMc(CharacterSet set)
        {
            set
            .AddRange('\u093e', '\u0940')
            .AddRange('\u0949', '\u094c')
            .AddRange('\u09be', '\u09c0')
            .AddRange('\u0a3e', '\u0a40')
            .AddRange('\u0abe', '\u0ac0')
            .AddRange('\u0bc6', '\u0bc8')
            .AddRange('\u0bca', '\u0bcc')
            .AddRange('\u0c01', '\u0c03')
            .AddRange('\u0c41', '\u0c44')
            .AddRange('\u0cc0', '\u0cc4')
            .AddRange('\u0d3e', '\u0d40')
            .AddRange('\u0d46', '\u0d48')
            .AddRange('\u0d4a', '\u0d4c')
            .AddRange('\u0dcf', '\u0dd1')
            .AddRange('\u0dd8', '\u0ddf')
            .AddRange('\u17be', '\u17c5')
            .AddRange('\u1923', '\u1926')
            .AddRange('\u1929', '\u192b')
            .AddRange('\u1933', '\u1938')
            .AddRange('\u19b0', '\u19c0')
            .AddRange('\u1a19', '\u1a1b')
            .AddRange('\u1b3d', '\u1b41')
            .AddCharacter('\u0903')
            .AddCharacter('\u0982')
            .AddCharacter('\u0983')
            .AddCharacter('\u09c7')
            .AddCharacter('\u09c8')
            .AddCharacter('\u09cb')
            .AddCharacter('\u09cc')
            .AddCharacter('\u09d7')
            .AddCharacter('\u0a03')
            .AddCharacter('\u0a83')
            .AddCharacter('\u0ac9')
            .AddCharacter('\u0acb')
            .AddCharacter('\u0acc')
            .AddCharacter('\u0b02')
            .AddCharacter('\u0b03')
            .AddCharacter('\u0b3e')
            .AddCharacter('\u0b40')
            .AddCharacter('\u0b47')
            .AddCharacter('\u0b48')
            .AddCharacter('\u0b4b')
            .AddCharacter('\u0b4c')
            .AddCharacter('\u0b57')
            .AddCharacter('\u0bbe')
            .AddCharacter('\u0bbf')
            .AddCharacter('\u0bc1')
            .AddCharacter('\u0bc2')
            .AddCharacter('\u0bd7')
            .AddCharacter('\u0c82')
            .AddCharacter('\u0c83')
            .AddCharacter('\u0cbe')
            .AddCharacter('\u0cc7')
            .AddCharacter('\u0cc8')
            .AddCharacter('\u0cca')
            .AddCharacter('\u0ccb')
            .AddCharacter('\u0cd5')
            .AddCharacter('\u0cd6')
            .AddCharacter('\u0d02')
            .AddCharacter('\u0d03')
            .AddCharacter('\u0d57')
            .AddCharacter('\u0d82')
            .AddCharacter('\u0d83')
            .AddCharacter('\u0df2')
            .AddCharacter('\u0df3')
            .AddCharacter('\u0f3e')
            .AddCharacter('\u0f3f')
            .AddCharacter('\u0f7f')
            .AddCharacter('\u102c')
            .AddCharacter('\u1031')
            .AddCharacter('\u1038')
            .AddCharacter('\u1056')
            .AddCharacter('\u1057')
            .AddCharacter('\u17b6')
            .AddCharacter('\u17c7')
            .AddCharacter('\u17c8')
            .AddCharacter('\u1930')
            .AddCharacter('\u1931')
            .AddCharacter('\u19c8')
            .AddCharacter('\u19c9')
            .AddCharacter('\u1b04')
            .AddCharacter('\u1b35')
            .AddCharacter('\u1b3b')
            .AddCharacter('\u1b43')
            .AddCharacter('\u1b44')
            .AddCharacter('\ua802')
            .AddCharacter('\ua823')
            .AddCharacter('\ua824')
            .AddCharacter('\ua827');
        }

        #endregion //AddCategoryMc

        #region AddCategoryMe

        private static void AddCategoryMe(CharacterSet set)
        {
            set
            .AddRange('\u20dd', '\u20e0')
            .AddRange('\u20e2', '\u20e4')
            .AddCharacter('\u0488')
            .AddCharacter('\u0489')
            .AddCharacter('\u06de');
        }

        #endregion //AddCategoryMe

        #region AddCategoryM

        private static void AddCategoryM(CharacterSet set)
        {
            AddCategoryMn(set);
            AddCategoryMc(set);
            AddCategoryMe(set);
        }

        #endregion //AddCategoryM

        #region AddCategoryNd

        private static void AddCategoryNd(CharacterSet set)
        {
            set
            .AddRange('\u0030', '\u0039')
            .AddRange('\u0660', '\u0669')
            .AddRange('\u06f0', '\u06f9')
            .AddRange('\u07c0', '\u07c9')
            .AddRange('\u0966', '\u096f')
            .AddRange('\u09e6', '\u09ef')
            .AddRange('\u0a66', '\u0a6f')
            .AddRange('\u0ae6', '\u0aef')
            .AddRange('\u0b66', '\u0b6f')
            .AddRange('\u0be6', '\u0bef')
            .AddRange('\u0c66', '\u0c6f')
            .AddRange('\u0ce6', '\u0cef')
            .AddRange('\u0d66', '\u0d6f')
            .AddRange('\u0e50', '\u0e59')
            .AddRange('\u0ed0', '\u0ed9')
            .AddRange('\u0f20', '\u0f29')
            .AddRange('\u1040', '\u1049')
            .AddRange('\u17e0', '\u17e9')
            .AddRange('\u1810', '\u1819')
            .AddRange('\u1946', '\u194f')
            .AddRange('\u19d0', '\u19d9')
            .AddRange('\u1b50', '\u1b59')
            .AddRange('\uff10', '\uff19');
        }

        #endregion //AddCategoryNd

        #region AddCategoryNl

        private static void AddCategoryNl(CharacterSet set)
        {
            set
            .AddRange('\u16ee', '\u16f0')
            .AddRange('\u2160', '\u2182')
            .AddRange('\u3021', '\u3029')
            .AddRange('\u3038', '\u303a')
            .AddCharacter('\u3007');
        }

        #endregion //AddCategoryNl

        #region AddCategoryNo

        private static void AddCategoryNo(CharacterSet set)
        {
            set
            .AddRange('\u00bc', '\u00be')
            .AddRange('\u09f4', '\u09f9')
            .AddRange('\u0bf0', '\u0bf2')
            .AddRange('\u0f2a', '\u0f33')
            .AddRange('\u1369', '\u137c')
            .AddRange('\u17f0', '\u17f9')
            .AddRange('\u2074', '\u2079')
            .AddRange('\u2080', '\u2089')
            .AddRange('\u2153', '\u215f')
            .AddRange('\u2460', '\u249b')
            .AddRange('\u24ea', '\u24ff')
            .AddRange('\u2776', '\u2793')
            .AddRange('\u3192', '\u3195')
            .AddRange('\u3220', '\u3229')
            .AddRange('\u3251', '\u325f')
            .AddRange('\u3280', '\u3289')
            .AddRange('\u32b1', '\u32bf')
            .AddCharacter('\u00b2')
            .AddCharacter('\u00b3')
            .AddCharacter('\u00b9')
            .AddCharacter('\u2070')
            .AddCharacter('\u2cfd');
        }

        #endregion //AddCategoryNo

        #region AddCategoryN

        private static void AddCategoryN(CharacterSet set)
        {
            AddCategoryNd(set);
            AddCategoryNl(set);
            AddCategoryNo(set);
        }

        #endregion //AddCategoryN

        #region AddCategoryPc

        private static void AddCategoryPc(CharacterSet set)
        {
            set
            .AddRange('\ufe4d', '\ufe4f')
            .AddCharacter('\u005f')
            .AddCharacter('\u203f')
            .AddCharacter('\u2040')
            .AddCharacter('\u2054')
            .AddCharacter('\ufe33')
            .AddCharacter('\ufe34')
            .AddCharacter('\uff3f');
        }

        #endregion //AddCategoryPc

        #region AddCategoryPd

        private static void AddCategoryPd(CharacterSet set)
        {
            set
            .AddRange('\u2010', '\u2015')
            .AddCharacter('\u002d')
            .AddCharacter('\u00ad')
            .AddCharacter('\u058a')
            .AddCharacter('\u1806')
            .AddCharacter('\u2e17')
            .AddCharacter('\u301c')
            .AddCharacter('\u3030')
            .AddCharacter('\u30a0')
            .AddCharacter('\ufe31')
            .AddCharacter('\ufe32')
            .AddCharacter('\ufe58')
            .AddCharacter('\ufe63')
            .AddCharacter('\uff0d');
        }

        #endregion //AddCategoryPd

        #region AddCategoryPs

        private static void AddCategoryPs(CharacterSet set)
        {
            set
            .AddCharacter('\u0028')
            .AddCharacter('\u005b')
            .AddCharacter('\u007b')
            .AddCharacter('\u0f3a')
            .AddCharacter('\u0f3c')
            .AddCharacter('\u169b')
            .AddCharacter('\u201a')
            .AddCharacter('\u201e')
            .AddCharacter('\u2045')
            .AddCharacter('\u207d')
            .AddCharacter('\u208d')
            .AddCharacter('\u2329')
            .AddCharacter('\u2768')
            .AddCharacter('\u276a')
            .AddCharacter('\u276c')
            .AddCharacter('\u276e')
            .AddCharacter('\u2770')
            .AddCharacter('\u2772')
            .AddCharacter('\u2774')
            .AddCharacter('\u27c5')
            .AddCharacter('\u27e6')
            .AddCharacter('\u27e8')
            .AddCharacter('\u27ea')
            .AddCharacter('\u2983')
            .AddCharacter('\u2985')
            .AddCharacter('\u2987')
            .AddCharacter('\u2989')
            .AddCharacter('\u298b')
            .AddCharacter('\u298d')
            .AddCharacter('\u298f')
            .AddCharacter('\u2991')
            .AddCharacter('\u2993')
            .AddCharacter('\u2995')
            .AddCharacter('\u2997')
            .AddCharacter('\u29d8')
            .AddCharacter('\u29da')
            .AddCharacter('\u29fc')
            .AddCharacter('\u3008')
            .AddCharacter('\u300a')
            .AddCharacter('\u300c')
            .AddCharacter('\u300e')
            .AddCharacter('\u3010')
            .AddCharacter('\u3014')
            .AddCharacter('\u3016')
            .AddCharacter('\u3018')
            .AddCharacter('\u301a')
            .AddCharacter('\u301d')
            .AddCharacter('\ufd3e')
            .AddCharacter('\ufe17')
            .AddCharacter('\ufe35')
            .AddCharacter('\ufe37')
            .AddCharacter('\ufe39')
            .AddCharacter('\ufe3b')
            .AddCharacter('\ufe3d')
            .AddCharacter('\ufe3f')
            .AddCharacter('\ufe41')
            .AddCharacter('\ufe43')
            .AddCharacter('\ufe47')
            .AddCharacter('\ufe59')
            .AddCharacter('\ufe5b')
            .AddCharacter('\ufe5d')
            .AddCharacter('\uff08')
            .AddCharacter('\uff3b')
            .AddCharacter('\uff5b')
            .AddCharacter('\uff5f')
            .AddCharacter('\uff62');
        }

        #endregion //AddCategoryPs

        #region AddCategoryPe

        private static void AddCategoryPe(CharacterSet set)
        {
            set
            .AddCharacter('\u0029')
            .AddCharacter('\u005d')
            .AddCharacter('\u007d')
            .AddCharacter('\u0f3b')
            .AddCharacter('\u0f3d')
            .AddCharacter('\u169c')
            .AddCharacter('\u2046')
            .AddCharacter('\u207e')
            .AddCharacter('\u208e')
            .AddCharacter('\u232a')
            .AddCharacter('\u2769')
            .AddCharacter('\u276b')
            .AddCharacter('\u276d')
            .AddCharacter('\u276f')
            .AddCharacter('\u2771')
            .AddCharacter('\u2773')
            .AddCharacter('\u2775')
            .AddCharacter('\u27c6')
            .AddCharacter('\u27e7')
            .AddCharacter('\u27e9')
            .AddCharacter('\u27eb')
            .AddCharacter('\u2984')
            .AddCharacter('\u2986')
            .AddCharacter('\u2988')
            .AddCharacter('\u298a')
            .AddCharacter('\u298c')
            .AddCharacter('\u298e')
            .AddCharacter('\u2990')
            .AddCharacter('\u2992')
            .AddCharacter('\u2994')
            .AddCharacter('\u2996')
            .AddCharacter('\u2998')
            .AddCharacter('\u29d9')
            .AddCharacter('\u29db')
            .AddCharacter('\u29fd')
            .AddCharacter('\u3009')
            .AddCharacter('\u300b')
            .AddCharacter('\u300d')
            .AddCharacter('\u300f')
            .AddCharacter('\u3011')
            .AddCharacter('\u3015')
            .AddCharacter('\u3017')
            .AddCharacter('\u3019')
            .AddCharacter('\u301b')
            .AddCharacter('\u301e')
            .AddCharacter('\u301f')
            .AddCharacter('\ufd3f')
            .AddCharacter('\ufe18')
            .AddCharacter('\ufe36')
            .AddCharacter('\ufe38')
            .AddCharacter('\ufe3a')
            .AddCharacter('\ufe3c')
            .AddCharacter('\ufe3e')
            .AddCharacter('\ufe40')
            .AddCharacter('\ufe42')
            .AddCharacter('\ufe44')
            .AddCharacter('\ufe48')
            .AddCharacter('\ufe5a')
            .AddCharacter('\ufe5c')
            .AddCharacter('\ufe5e')
            .AddCharacter('\uff09')
            .AddCharacter('\uff3d')
            .AddCharacter('\uff5d')
            .AddCharacter('\uff60')
            .AddCharacter('\uff63');
        }

        #endregion //AddCategoryPe

        #region AddCategoryPi

        private static void AddCategoryPi(CharacterSet set)
        {
            set
            .AddCharacter('\u00ab')
            .AddCharacter('\u2018')
            .AddCharacter('\u201b')
            .AddCharacter('\u201c')
            .AddCharacter('\u201f')
            .AddCharacter('\u2039')
            .AddCharacter('\u2e02')
            .AddCharacter('\u2e04')
            .AddCharacter('\u2e09')
            .AddCharacter('\u2e0c')
            .AddCharacter('\u2e1c');
        }

        #endregion //AddCategoryPi

        #region AddCategoryPf

        private static void AddCategoryPf(CharacterSet set)
        {
            set
            .AddCharacter('\u00bb')
            .AddCharacter('\u2019')
            .AddCharacter('\u201d')
            .AddCharacter('\u203a')
            .AddCharacter('\u2e03')
            .AddCharacter('\u2e05')
            .AddCharacter('\u2e0a')
            .AddCharacter('\u2e0d')
            .AddCharacter('\u2e1d');
        }

        #endregion //AddCategoryPf

        #region AddCategoryPo

        private static void AddCategoryPo(CharacterSet set)
        {
            set
            .AddRange('\u0021', '\u0023')
            .AddRange('\u0025', '\u0027')
            .AddRange('\u055a', '\u055f')
            .AddRange('\u066a', '\u066d')
            .AddRange('\u0700', '\u070d')
            .AddRange('\u07f7', '\u07f9')
            .AddRange('\u0f04', '\u0f12')
            .AddRange('\u104a', '\u104f')
            .AddRange('\u1361', '\u1368')
            .AddRange('\u16eb', '\u16ed')
            .AddRange('\u17d4', '\u17d6')
            .AddRange('\u17d8', '\u17da')
            .AddRange('\u1800', '\u1805')
            .AddRange('\u1807', '\u180a')
            .AddRange('\u1b5a', '\u1b60')
            .AddRange('\u2020', '\u2027')
            .AddRange('\u2030', '\u2038')
            .AddRange('\u203b', '\u203e')
            .AddRange('\u2041', '\u2043')
            .AddRange('\u2047', '\u2051')
            .AddRange('\u2055', '\u205e')
            .AddRange('\u2cf9', '\u2cfc')
            .AddRange('\u2e06', '\u2e08')
            .AddRange('\u2e0e', '\u2e16')
            .AddRange('\u3001', '\u3003')
            .AddRange('\ua874', '\ua877')
            .AddRange('\ufe10', '\ufe16')
            .AddRange('\ufe49', '\ufe4c')
            .AddRange('\ufe50', '\ufe52')
            .AddRange('\ufe54', '\ufe57')
            .AddRange('\ufe5f', '\ufe61')
            .AddRange('\uff01', '\uff03')
            .AddRange('\uff05', '\uff07')
            .AddCharacter('\u002a')
            .AddCharacter('\u002c')
            .AddCharacter('\u002e')
            .AddCharacter('\u002f')
            .AddCharacter('\u003a')
            .AddCharacter('\u003b')
            .AddCharacter('\u003f')
            .AddCharacter('\u0040')
            .AddCharacter('\u005c')
            .AddCharacter('\u00a1')
            .AddCharacter('\u00b7')
            .AddCharacter('\u00bf')
            .AddCharacter('\u037e')
            .AddCharacter('\u0387')
            .AddCharacter('\u0589')
            .AddCharacter('\u05be')
            .AddCharacter('\u05c0')
            .AddCharacter('\u05c3')
            .AddCharacter('\u05c6')
            .AddCharacter('\u05f3')
            .AddCharacter('\u05f4')
            .AddCharacter('\u060c')
            .AddCharacter('\u060d')
            .AddCharacter('\u061b')
            .AddCharacter('\u061e')
            .AddCharacter('\u061f')
            .AddCharacter('\u06d4')
            .AddCharacter('\u0964')
            .AddCharacter('\u0965')
            .AddCharacter('\u0970')
            .AddCharacter('\u0df4')
            .AddCharacter('\u0e4f')
            .AddCharacter('\u0e5a')
            .AddCharacter('\u0e5b')
            .AddCharacter('\u0f85')
            .AddCharacter('\u0fd0')
            .AddCharacter('\u0fd1')
            .AddCharacter('\u10fb')
            .AddCharacter('\u166d')
            .AddCharacter('\u166e')
            .AddCharacter('\u1735')
            .AddCharacter('\u1736')
            .AddCharacter('\u1944')
            .AddCharacter('\u1945')
            .AddCharacter('\u19de')
            .AddCharacter('\u19df')
            .AddCharacter('\u1a1e')
            .AddCharacter('\u1a1f')
            .AddCharacter('\u2016')
            .AddCharacter('\u2017')
            .AddCharacter('\u2053')
            .AddCharacter('\u2cfe')
            .AddCharacter('\u2cff')
            .AddCharacter('\u2e00')
            .AddCharacter('\u2e01')
            .AddCharacter('\u2e0b')
            .AddCharacter('\u303d')
            .AddCharacter('\u30fb')
            .AddCharacter('\ufe19')
            .AddCharacter('\ufe30')
            .AddCharacter('\ufe45')
            .AddCharacter('\ufe46')
            .AddCharacter('\ufe68')
            .AddCharacter('\ufe6a')
            .AddCharacter('\ufe6b')
            .AddCharacter('\uff0a')
            .AddCharacter('\uff0c')
            .AddCharacter('\uff0e')
            .AddCharacter('\uff0f')
            .AddCharacter('\uff1a')
            .AddCharacter('\uff1b')
            .AddCharacter('\uff1f')
            .AddCharacter('\uff20')
            .AddCharacter('\uff3c')
            .AddCharacter('\uff61')
            .AddCharacter('\uff64')
            .AddCharacter('\uff65');
        }

        #endregion //AddCategoryPo

        #region AddCategoryP

        private static void AddCategoryP(CharacterSet set)
        {
            AddCategoryPc(set);
            AddCategoryPd(set);
            AddCategoryPs(set);
            AddCategoryPe(set);
            AddCategoryPi(set);
            AddCategoryPf(set);
            AddCategoryPo(set);
        }

        #endregion //AddCategoryP

        #region AddCategorySm

        private static void AddCategorySm(CharacterSet set)
        {
            set
            .AddRange('\u003c', '\u003e')
            .AddRange('\u207a', '\u207c')
            .AddRange('\u208a', '\u208c')
            .AddRange('\u2140', '\u2144')
            .AddRange('\u2190', '\u2194')
            .AddRange('\u21f4', '\u22ff')
            .AddRange('\u2308', '\u230b')
            .AddRange('\u239b', '\u23b3')
            .AddRange('\u23dc', '\u23e1')
            .AddRange('\u25f8', '\u25ff')
            .AddRange('\u27c0', '\u27c4')
            .AddRange('\u27c7', '\u27ca')
            .AddRange('\u27d0', '\u27e5')
            .AddRange('\u27f0', '\u27ff')
            .AddRange('\u2900', '\u2982')
            .AddRange('\u2999', '\u29d7')
            .AddRange('\u29dc', '\u29fb')
            .AddRange('\u29fe', '\u2aff')
            .AddRange('\ufe64', '\ufe66')
            .AddRange('\uff1c', '\uff1e')
            .AddRange('\uffe9', '\uffec')
            .AddCharacter('\u002b')
            .AddCharacter('\u007c')
            .AddCharacter('\u007e')
            .AddCharacter('\u00ac')
            .AddCharacter('\u00b1')
            .AddCharacter('\u00d7')
            .AddCharacter('\u00f7')
            .AddCharacter('\u03f6')
            .AddCharacter('\u2044')
            .AddCharacter('\u2052')
            .AddCharacter('\u214b')
            .AddCharacter('\u219a')
            .AddCharacter('\u219b')
            .AddCharacter('\u21a0')
            .AddCharacter('\u21a3')
            .AddCharacter('\u21a6')
            .AddCharacter('\u21ae')
            .AddCharacter('\u21ce')
            .AddCharacter('\u21cf')
            .AddCharacter('\u21d2')
            .AddCharacter('\u21d4')
            .AddCharacter('\u2320')
            .AddCharacter('\u2321')
            .AddCharacter('\u237c')
            .AddCharacter('\u25b7')
            .AddCharacter('\u25c1')
            .AddCharacter('\u266f')
            .AddCharacter('\ufb29')
            .AddCharacter('\ufe62')
            .AddCharacter('\uff0b')
            .AddCharacter('\uff5c')
            .AddCharacter('\uff5e')
            .AddCharacter('\uffe2');
        }

        #endregion //AddCategorySm

        #region AddCategorySc

        private static void AddCategorySc(CharacterSet set)
        {
            set
            .AddRange('\u00a2', '\u00a5')
            .AddRange('\u20a0', '\u20b5')
            .AddCharacter('\u0024')
            .AddCharacter('\u060b')
            .AddCharacter('\u09f2')
            .AddCharacter('\u09f3')
            .AddCharacter('\u0af1')
            .AddCharacter('\u0bf9')
            .AddCharacter('\u0e3f')
            .AddCharacter('\u17db')
            .AddCharacter('\ufdfc')
            .AddCharacter('\ufe69')
            .AddCharacter('\uff04')
            .AddCharacter('\uffe0')
            .AddCharacter('\uffe1')
            .AddCharacter('\uffe5')
            .AddCharacter('\uffe6');
        }

        #endregion //AddCategorySc

        #region AddCategorySk

        private static void AddCategorySk(CharacterSet set)
        {
            set
            .AddRange('\u02c2', '\u02c5')
            .AddRange('\u02d2', '\u02df')
            .AddRange('\u02e5', '\u02ed')
            .AddRange('\u02ef', '\u02ff')
            .AddRange('\u1fbf', '\u1fc1')
            .AddRange('\u1fcd', '\u1fcf')
            .AddRange('\u1fdd', '\u1fdf')
            .AddRange('\u1fed', '\u1fef')
            .AddRange('\ua700', '\ua716')
            .AddCharacter('\u005e')
            .AddCharacter('\u0060')
            .AddCharacter('\u00a8')
            .AddCharacter('\u00af')
            .AddCharacter('\u00b4')
            .AddCharacter('\u00b8')
            .AddCharacter('\u0374')
            .AddCharacter('\u0375')
            .AddCharacter('\u0384')
            .AddCharacter('\u0385')
            .AddCharacter('\u1fbd')
            .AddCharacter('\u1ffd')
            .AddCharacter('\u1ffe')
            .AddCharacter('\u309b')
            .AddCharacter('\u309c')
            .AddCharacter('\ua720')
            .AddCharacter('\ua721')
            .AddCharacter('\uff3e')
            .AddCharacter('\uff40')
            .AddCharacter('\uffe3');
        }

        #endregion //AddCategorySk

        #region AddCategorySo

        private static void AddCategorySo(CharacterSet set)
        {
            set
            .AddRange('\u0bf3', '\u0bf8')
            .AddRange('\u0f01', '\u0f03')
            .AddRange('\u0f13', '\u0f17')
            .AddRange('\u0f1a', '\u0f1f')
            .AddRange('\u0fbe', '\u0fc5')
            .AddRange('\u0fc7', '\u0fcc')
            .AddRange('\u1390', '\u1399')
            .AddRange('\u19e0', '\u19ff')
            .AddRange('\u1b61', '\u1b6a')
            .AddRange('\u1b74', '\u1b7c')
            .AddRange('\u2103', '\u2106')
            .AddRange('\u2116', '\u2118')
            .AddRange('\u211e', '\u2123')
            .AddRange('\u2195', '\u2199')
            .AddRange('\u219c', '\u219f')
            .AddRange('\u21a7', '\u21ad')
            .AddRange('\u21af', '\u21cd')
            .AddRange('\u21d5', '\u21f3')
            .AddRange('\u2300', '\u2307')
            .AddRange('\u230c', '\u231f')
            .AddRange('\u2322', '\u2328')
            .AddRange('\u232b', '\u237b')
            .AddRange('\u237d', '\u239a')
            .AddRange('\u23b4', '\u23db')
            .AddRange('\u23e2', '\u23e7')
            .AddRange('\u2400', '\u2426')
            .AddRange('\u2440', '\u244a')
            .AddRange('\u249c', '\u24e9')
            .AddRange('\u2500', '\u25b6')
            .AddRange('\u25b8', '\u25c0')
            .AddRange('\u25c2', '\u25f7')
            .AddRange('\u2600', '\u266e')
            .AddRange('\u2670', '\u269c')
            .AddRange('\u26a0', '\u26b2')
            .AddRange('\u2701', '\u2704')
            .AddRange('\u2706', '\u2709')
            .AddRange('\u270c', '\u2727')
            .AddRange('\u2729', '\u274b')
            .AddRange('\u274f', '\u2752')
            .AddRange('\u2758', '\u275e')
            .AddRange('\u2761', '\u2767')
            .AddRange('\u2798', '\u27af')
            .AddRange('\u27b1', '\u27be')
            .AddRange('\u2800', '\u28ff')
            .AddRange('\u2b00', '\u2b1a')
            .AddRange('\u2b20', '\u2b23')
            .AddRange('\u2ce5', '\u2cea')
            .AddRange('\u2e80', '\u2e99')
            .AddRange('\u2e9b', '\u2ef3')
            .AddRange('\u2f00', '\u2fd5')
            .AddRange('\u2ff0', '\u2ffb')
            .AddRange('\u3196', '\u319f')
            .AddRange('\u31c0', '\u31cf')
            .AddRange('\u3200', '\u321e')
            .AddRange('\u322a', '\u3243')
            .AddRange('\u3260', '\u327f')
            .AddRange('\u328a', '\u32b0')
            .AddRange('\u32c0', '\u32fe')
            .AddRange('\u3300', '\u33ff')
            .AddRange('\u4dc0', '\u4dff')
            .AddRange('\ua490', '\ua4c6')
            .AddRange('\ua828', '\ua82b')
            .AddCharacter('\u00a6')
            .AddCharacter('\u00a7')
            .AddCharacter('\u00a9')
            .AddCharacter('\u00ae')
            .AddCharacter('\u00b0')
            .AddCharacter('\u00b6')
            .AddCharacter('\u0482')
            .AddCharacter('\u060e')
            .AddCharacter('\u060f')
            .AddCharacter('\u06e9')
            .AddCharacter('\u06fd')
            .AddCharacter('\u06fe')
            .AddCharacter('\u07f6')
            .AddCharacter('\u09fa')
            .AddCharacter('\u0b70')
            .AddCharacter('\u0bfa')
            .AddCharacter('\u0cf1')
            .AddCharacter('\u0cf2')
            .AddCharacter('\u0f34')
            .AddCharacter('\u0f36')
            .AddCharacter('\u0f38')
            .AddCharacter('\u0fcf')
            .AddCharacter('\u1360')
            .AddCharacter('\u1940')
            .AddCharacter('\u2100')
            .AddCharacter('\u2101')
            .AddCharacter('\u2108')
            .AddCharacter('\u2109')
            .AddCharacter('\u2114')
            .AddCharacter('\u2125')
            .AddCharacter('\u2127')
            .AddCharacter('\u2129')
            .AddCharacter('\u212e')
            .AddCharacter('\u213a')
            .AddCharacter('\u213b')
            .AddCharacter('\u214a')
            .AddCharacter('\u214c')
            .AddCharacter('\u214d')
            .AddCharacter('\u21a1')
            .AddCharacter('\u21a2')
            .AddCharacter('\u21a4')
            .AddCharacter('\u21a5')
            .AddCharacter('\u21d0')
            .AddCharacter('\u21d1')
            .AddCharacter('\u21d3')
            .AddCharacter('\u274d')
            .AddCharacter('\u2756')
            .AddCharacter('\u2794')
            .AddCharacter('\u3004')
            .AddCharacter('\u3012')
            .AddCharacter('\u3013')
            .AddCharacter('\u3020')
            .AddCharacter('\u3036')
            .AddCharacter('\u3037')
            .AddCharacter('\u303e')
            .AddCharacter('\u303f')
            .AddCharacter('\u3190')
            .AddCharacter('\u3191')
            .AddCharacter('\u3250')
            .AddCharacter('\ufdfd')
            .AddCharacter('\uffe4')
            .AddCharacter('\uffe8')
            .AddCharacter('\uffed')
            .AddCharacter('\uffee')
            .AddCharacter('\ufffc')
            .AddCharacter('\ufffd');
        }

        #endregion //AddCategorySo

        #region AddCategoryS

        private static void AddCategoryS(CharacterSet set)
        {
            AddCategorySm(set);
            AddCategorySc(set);
            AddCategorySk(set);
            AddCategorySo(set);
        }

        #endregion //AddCategoryS

        #region AddCategoryZs

        private static void AddCategoryZs(CharacterSet set)
        {
            set
            .AddRange('\u2000', '\u200a')
            .AddCharacter('\u0020')
            .AddCharacter('\u00a0')
            .AddCharacter('\u1680')
            .AddCharacter('\u180e')
            .AddCharacter('\u202f')
            .AddCharacter('\u205f')
            .AddCharacter('\u3000');
        }

        #endregion //AddCategoryZs

        #region AddCategoryZl

        private static void AddCategoryZl(CharacterSet set)
        {
            set
            .AddCharacter('\u2028');
        }

        #endregion //AddCategoryZl

        #region AddCategoryZp

        private static void AddCategoryZp(CharacterSet set)
        {
            set
            .AddCharacter('\u2029');
        }

        #endregion //AddCategoryZp

        #region AddCategoryZ

        private static void AddCategoryZ(CharacterSet set)
        {
            AddCategoryZs(set);
            AddCategoryZl(set);
            AddCategoryZp(set);
        }

        #endregion //AddCategoryZ

        #region AddCategoryCc

        private static void AddCategoryCc(CharacterSet set)
        {
            set
            .AddRange('\u0000', '\u001f')
            .AddRange('\u007f', '\u009f');
        }

        #endregion //AddCategoryCc

        #region AddCategoryCf

        private static void AddCategoryCf(CharacterSet set)
        {
            set
            .AddRange('\u0600', '\u0603')
            .AddRange('\u200b', '\u200f')
            .AddRange('\u202a', '\u202e')
            .AddRange('\u2060', '\u2063')
            .AddRange('\u206a', '\u206f')
            .AddRange('\ufff9', '\ufffb')
            .AddCharacter('\u06dd')
            .AddCharacter('\u070f')
            .AddCharacter('\u17b4')
            .AddCharacter('\u17b5')
            .AddCharacter('\ufeff');
        }

        #endregion //AddCategoryCf

        #region AddCategoryCs

        private static void AddCategoryCs(CharacterSet set)
        {
            set
            .AddRange('\ud800', '\udfff');
        }

        #endregion //AddCategoryCs

        #region AddCategoryCo

        private static void AddCategoryCo(CharacterSet set)
        {
            set
            .AddRange('\ue000', '\uf8ff');
        }

        #endregion //AddCategoryCo

        #region AddCategoryCn

        private static void AddCategoryCn(CharacterSet set)
        {
            set
            .AddRange('\u0370', '\u0373')
            .AddRange('\u0376', '\u0379')
            .AddRange('\u037f', '\u0383')
            .AddRange('\u0514', '\u0530')
            .AddRange('\u058b', '\u0590')
            .AddRange('\u05c8', '\u05cf')
            .AddRange('\u05eb', '\u05ef')
            .AddRange('\u05f5', '\u05ff')
            .AddRange('\u0604', '\u060a')
            .AddRange('\u0616', '\u061a')
            .AddRange('\u063b', '\u063f')
            .AddRange('\u076e', '\u077f')
            .AddRange('\u07b2', '\u07bf')
            .AddRange('\u07fb', '\u0900')
            .AddRange('\u0955', '\u0957')
            .AddRange('\u0971', '\u097a')
            .AddRange('\u09b3', '\u09b5')
            .AddRange('\u09cf', '\u09d6')
            .AddRange('\u09d8', '\u09db')
            .AddRange('\u09fb', '\u0a00')
            .AddRange('\u0a0b', '\u0a0e')
            .AddRange('\u0a43', '\u0a46')
            .AddRange('\u0a4e', '\u0a58')
            .AddRange('\u0a5f', '\u0a65')
            .AddRange('\u0a75', '\u0a80')
            .AddRange('\u0ad1', '\u0adf')
            .AddRange('\u0af2', '\u0b00')
            .AddRange('\u0b44', '\u0b46')
            .AddRange('\u0b4e', '\u0b55')
            .AddRange('\u0b58', '\u0b5b')
            .AddRange('\u0b62', '\u0b65')
            .AddRange('\u0b72', '\u0b81')
            .AddRange('\u0b8b', '\u0b8d')
            .AddRange('\u0b96', '\u0b98')
            .AddRange('\u0ba0', '\u0ba2')
            .AddRange('\u0ba5', '\u0ba7')
            .AddRange('\u0bab', '\u0bad')
            .AddRange('\u0bba', '\u0bbd')
            .AddRange('\u0bc3', '\u0bc5')
            .AddRange('\u0bce', '\u0bd6')
            .AddRange('\u0bd8', '\u0be5')
            .AddRange('\u0bfb', '\u0c00')
            .AddRange('\u0c3a', '\u0c3d')
            .AddRange('\u0c4e', '\u0c54')
            .AddRange('\u0c57', '\u0c5f')
            .AddRange('\u0c62', '\u0c65')
            .AddRange('\u0c70', '\u0c81')
            .AddRange('\u0cce', '\u0cd4')
            .AddRange('\u0cd7', '\u0cdd')
            .AddRange('\u0cf3', '\u0d01')
            .AddRange('\u0d3a', '\u0d3d')
            .AddRange('\u0d4e', '\u0d56')
            .AddRange('\u0d58', '\u0d5f')
            .AddRange('\u0d62', '\u0d65')
            .AddRange('\u0d70', '\u0d81')
            .AddRange('\u0d97', '\u0d99')
            .AddRange('\u0dc7', '\u0dc9')
            .AddRange('\u0dcb', '\u0dce')
            .AddRange('\u0de0', '\u0df1')
            .AddRange('\u0df5', '\u0e00')
            .AddRange('\u0e3b', '\u0e3e')
            .AddRange('\u0e5c', '\u0e80')
            .AddRange('\u0e8e', '\u0e93')
            .AddRange('\u0ede', '\u0eff')
            .AddRange('\u0f6b', '\u0f70')
            .AddRange('\u0f8c', '\u0f8f')
            .AddRange('\u0fd2', '\u0fff')
            .AddRange('\u1033', '\u1035')
            .AddRange('\u103a', '\u103f')
            .AddRange('\u105a', '\u109f')
            .AddRange('\u10c6', '\u10cf')
            .AddRange('\u10fd', '\u10ff')
            .AddRange('\u115a', '\u115e')
            .AddRange('\u11a3', '\u11a7')
            .AddRange('\u11fa', '\u11ff')
            .AddRange('\u135b', '\u135e')
            .AddRange('\u137d', '\u137f')
            .AddRange('\u139a', '\u139f')
            .AddRange('\u13f5', '\u1400')
            .AddRange('\u1677', '\u167f')
            .AddRange('\u169d', '\u169f')
            .AddRange('\u16f1', '\u16ff')
            .AddRange('\u1715', '\u171f')
            .AddRange('\u1737', '\u173f')
            .AddRange('\u1754', '\u175f')
            .AddRange('\u1774', '\u177f')
            .AddRange('\u17ea', '\u17ef')
            .AddRange('\u17fa', '\u17ff')
            .AddRange('\u181a', '\u181f')
            .AddRange('\u1878', '\u187f')
            .AddRange('\u18aa', '\u18ff')
            .AddRange('\u191d', '\u191f')
            .AddRange('\u192c', '\u192f')
            .AddRange('\u193c', '\u193f')
            .AddRange('\u1941', '\u1943')
            .AddRange('\u1975', '\u197f')
            .AddRange('\u19aa', '\u19af')
            .AddRange('\u19ca', '\u19cf')
            .AddRange('\u19da', '\u19dd')
            .AddRange('\u1a20', '\u1aff')
            .AddRange('\u1b4c', '\u1b4f')
            .AddRange('\u1b7d', '\u1cff')
            .AddRange('\u1dcb', '\u1dfd')
            .AddRange('\u1e9c', '\u1e9f')
            .AddRange('\u1efa', '\u1eff')
            .AddRange('\u2064', '\u2069')
            .AddRange('\u2095', '\u209f')
            .AddRange('\u20b6', '\u20cf')
            .AddRange('\u20f0', '\u20ff')
            .AddRange('\u214f', '\u2152')
            .AddRange('\u2185', '\u218f')
            .AddRange('\u23e8', '\u23ff')
            .AddRange('\u2427', '\u243f')
            .AddRange('\u244b', '\u245f')
            .AddRange('\u269d', '\u269f')
            .AddRange('\u26b3', '\u2700')
            .AddRange('\u2753', '\u2755')
            .AddRange('\u2795', '\u2797')
            .AddRange('\u27cb', '\u27cf')
            .AddRange('\u27ec', '\u27ef')
            .AddRange('\u2b1b', '\u2b1f')
            .AddRange('\u2b24', '\u2bff')
            .AddRange('\u2c6d', '\u2c73')
            .AddRange('\u2c78', '\u2c7f')
            .AddRange('\u2ceb', '\u2cf8')
            .AddRange('\u2d26', '\u2d2f')
            .AddRange('\u2d66', '\u2d6e')
            .AddRange('\u2d70', '\u2d7f')
            .AddRange('\u2d97', '\u2d9f')
            .AddRange('\u2ddf', '\u2dff')
            .AddRange('\u2e18', '\u2e1b')
            .AddRange('\u2e1e', '\u2e7f')
            .AddRange('\u2ef4', '\u2eff')
            .AddRange('\u2fd6', '\u2fef')
            .AddRange('\u2ffc', '\u2fff')
            .AddRange('\u3100', '\u3104')
            .AddRange('\u312d', '\u3130')
            .AddRange('\u31b8', '\u31bf')
            .AddRange('\u31d0', '\u31ef')
            .AddRange('\u3244', '\u324f')
            .AddRange('\u4db6', '\u4dbf')
            .AddRange('\u9fbc', '\u9fff')
            .AddRange('\ua48d', '\ua48f')
            .AddRange('\ua4c7', '\ua6ff')
            .AddRange('\ua71b', '\ua71f')
            .AddRange('\ua722', '\ua7ff')
            .AddRange('\ua82c', '\ua83f')
            .AddRange('\ua878', '\uabff')
            .AddRange('\ud7a4', '\ud7ff')
            .AddRange('\ufa6b', '\ufa6f')
            .AddRange('\ufada', '\ufaff')
            .AddRange('\ufb07', '\ufb12')
            .AddRange('\ufb18', '\ufb1c')
            .AddRange('\ufbb2', '\ufbd2')
            .AddRange('\ufd40', '\ufd4f')
            .AddRange('\ufdc8', '\ufdef')
            .AddRange('\ufe1a', '\ufe1f')
            .AddRange('\ufe24', '\ufe2f')
            .AddRange('\ufe6c', '\ufe6f')
            .AddRange('\uffbf', '\uffc1')
            .AddRange('\uffdd', '\uffdf')
            .AddRange('\uffef', '\ufff8')
            .AddCharacter('\u038b')
            .AddCharacter('\u038d')
            .AddCharacter('\u03a2')
            .AddCharacter('\u03cf')
            .AddCharacter('\u0487')
            .AddCharacter('\u0557')
            .AddCharacter('\u0558')
            .AddCharacter('\u0560')
            .AddCharacter('\u0588')
            .AddCharacter('\u061c')
            .AddCharacter('\u061d')
            .AddCharacter('\u0620')
            .AddCharacter('\u065f')
            .AddCharacter('\u070e')
            .AddCharacter('\u074b')
            .AddCharacter('\u074c')
            .AddCharacter('\u093a')
            .AddCharacter('\u093b')
            .AddCharacter('\u094e')
            .AddCharacter('\u094f')
            .AddCharacter('\u0980')
            .AddCharacter('\u0984')
            .AddCharacter('\u098d')
            .AddCharacter('\u098e')
            .AddCharacter('\u0991')
            .AddCharacter('\u0992')
            .AddCharacter('\u09a9')
            .AddCharacter('\u09b1')
            .AddCharacter('\u09ba')
            .AddCharacter('\u09bb')
            .AddCharacter('\u09c5')
            .AddCharacter('\u09c6')
            .AddCharacter('\u09c9')
            .AddCharacter('\u09ca')
            .AddCharacter('\u09de')
            .AddCharacter('\u09e4')
            .AddCharacter('\u09e5')
            .AddCharacter('\u0a04')
            .AddCharacter('\u0a11')
            .AddCharacter('\u0a12')
            .AddCharacter('\u0a29')
            .AddCharacter('\u0a31')
            .AddCharacter('\u0a34')
            .AddCharacter('\u0a37')
            .AddCharacter('\u0a3a')
            .AddCharacter('\u0a3b')
            .AddCharacter('\u0a3d')
            .AddCharacter('\u0a49')
            .AddCharacter('\u0a4a')
            .AddCharacter('\u0a5d')
            .AddCharacter('\u0a84')
            .AddCharacter('\u0a8e')
            .AddCharacter('\u0a92')
            .AddCharacter('\u0aa9')
            .AddCharacter('\u0ab1')
            .AddCharacter('\u0ab4')
            .AddCharacter('\u0aba')
            .AddCharacter('\u0abb')
            .AddCharacter('\u0ac6')
            .AddCharacter('\u0aca')
            .AddCharacter('\u0ace')
            .AddCharacter('\u0acf')
            .AddCharacter('\u0ae4')
            .AddCharacter('\u0ae5')
            .AddCharacter('\u0af0')
            .AddCharacter('\u0b04')
            .AddCharacter('\u0b0d')
            .AddCharacter('\u0b0e')
            .AddCharacter('\u0b11')
            .AddCharacter('\u0b12')
            .AddCharacter('\u0b29')
            .AddCharacter('\u0b31')
            .AddCharacter('\u0b34')
            .AddCharacter('\u0b3a')
            .AddCharacter('\u0b3b')
            .AddCharacter('\u0b49')
            .AddCharacter('\u0b4a')
            .AddCharacter('\u0b5e')
            .AddCharacter('\u0b84')
            .AddCharacter('\u0b91')
            .AddCharacter('\u0b9b')
            .AddCharacter('\u0b9d')
            .AddCharacter('\u0bc9')
            .AddCharacter('\u0c04')
            .AddCharacter('\u0c0d')
            .AddCharacter('\u0c11')
            .AddCharacter('\u0c29')
            .AddCharacter('\u0c34')
            .AddCharacter('\u0c45')
            .AddCharacter('\u0c49')
            .AddCharacter('\u0c84')
            .AddCharacter('\u0c8d')
            .AddCharacter('\u0c91')
            .AddCharacter('\u0ca9')
            .AddCharacter('\u0cb4')
            .AddCharacter('\u0cba')
            .AddCharacter('\u0cbb')
            .AddCharacter('\u0cc5')
            .AddCharacter('\u0cc9')
            .AddCharacter('\u0cdf')
            .AddCharacter('\u0ce4')
            .AddCharacter('\u0ce5')
            .AddCharacter('\u0cf0')
            .AddCharacter('\u0d04')
            .AddCharacter('\u0d0d')
            .AddCharacter('\u0d11')
            .AddCharacter('\u0d29')
            .AddCharacter('\u0d44')
            .AddCharacter('\u0d45')
            .AddCharacter('\u0d49')
            .AddCharacter('\u0d84')
            .AddCharacter('\u0db2')
            .AddCharacter('\u0dbc')
            .AddCharacter('\u0dbe')
            .AddCharacter('\u0dbf')
            .AddCharacter('\u0dd5')
            .AddCharacter('\u0dd7')
            .AddCharacter('\u0e83')
            .AddCharacter('\u0e85')
            .AddCharacter('\u0e86')
            .AddCharacter('\u0e89')
            .AddCharacter('\u0e8b')
            .AddCharacter('\u0e8c')
            .AddCharacter('\u0e98')
            .AddCharacter('\u0ea0')
            .AddCharacter('\u0ea4')
            .AddCharacter('\u0ea6')
            .AddCharacter('\u0ea8')
            .AddCharacter('\u0ea9')
            .AddCharacter('\u0eac')
            .AddCharacter('\u0eba')
            .AddCharacter('\u0ebe')
            .AddCharacter('\u0ebf')
            .AddCharacter('\u0ec5')
            .AddCharacter('\u0ec7')
            .AddCharacter('\u0ece')
            .AddCharacter('\u0ecf')
            .AddCharacter('\u0eda')
            .AddCharacter('\u0edb')
            .AddCharacter('\u0f48')
            .AddCharacter('\u0f98')
            .AddCharacter('\u0fbd')
            .AddCharacter('\u0fcd')
            .AddCharacter('\u0fce')
            .AddCharacter('\u1022')
            .AddCharacter('\u1028')
            .AddCharacter('\u102b')
            .AddCharacter('\u1249')
            .AddCharacter('\u124e')
            .AddCharacter('\u124f')
            .AddCharacter('\u1257')
            .AddCharacter('\u1259')
            .AddCharacter('\u125e')
            .AddCharacter('\u125f')
            .AddCharacter('\u1289')
            .AddCharacter('\u128e')
            .AddCharacter('\u128f')
            .AddCharacter('\u12b1')
            .AddCharacter('\u12b6')
            .AddCharacter('\u12b7')
            .AddCharacter('\u12bf')
            .AddCharacter('\u12c1')
            .AddCharacter('\u12c6')
            .AddCharacter('\u12c7')
            .AddCharacter('\u12d7')
            .AddCharacter('\u1311')
            .AddCharacter('\u1316')
            .AddCharacter('\u1317')
            .AddCharacter('\u170d')
            .AddCharacter('\u176d')
            .AddCharacter('\u1771')
            .AddCharacter('\u17de')
            .AddCharacter('\u17df')
            .AddCharacter('\u180f')
            .AddCharacter('\u196e')
            .AddCharacter('\u196f')
            .AddCharacter('\u1a1c')
            .AddCharacter('\u1a1d')
            .AddCharacter('\u1f16')
            .AddCharacter('\u1f17')
            .AddCharacter('\u1f1e')
            .AddCharacter('\u1f1f')
            .AddCharacter('\u1f46')
            .AddCharacter('\u1f47')
            .AddCharacter('\u1f4e')
            .AddCharacter('\u1f4f')
            .AddCharacter('\u1f58')
            .AddCharacter('\u1f5a')
            .AddCharacter('\u1f5c')
            .AddCharacter('\u1f5e')
            .AddCharacter('\u1f7e')
            .AddCharacter('\u1f7f')
            .AddCharacter('\u1fb5')
            .AddCharacter('\u1fc5')
            .AddCharacter('\u1fd4')
            .AddCharacter('\u1fd5')
            .AddCharacter('\u1fdc')
            .AddCharacter('\u1ff0')
            .AddCharacter('\u1ff1')
            .AddCharacter('\u1ff5')
            .AddCharacter('\u1fff')
            .AddCharacter('\u2072')
            .AddCharacter('\u2073')
            .AddCharacter('\u208f')
            .AddCharacter('\u2705')
            .AddCharacter('\u270a')
            .AddCharacter('\u270b')
            .AddCharacter('\u2728')
            .AddCharacter('\u274c')
            .AddCharacter('\u274e')
            .AddCharacter('\u2757')
            .AddCharacter('\u275f')
            .AddCharacter('\u2760')
            .AddCharacter('\u27b0')
            .AddCharacter('\u27bf')
            .AddCharacter('\u2c2f')
            .AddCharacter('\u2c5f')
            .AddCharacter('\u2da7')
            .AddCharacter('\u2daf')
            .AddCharacter('\u2db7')
            .AddCharacter('\u2dbf')
            .AddCharacter('\u2dc7')
            .AddCharacter('\u2dcf')
            .AddCharacter('\u2dd7')
            .AddCharacter('\u2e9a')
            .AddCharacter('\u3040')
            .AddCharacter('\u3097')
            .AddCharacter('\u3098')
            .AddCharacter('\u318f')
            .AddCharacter('\u321f')
            .AddCharacter('\u32ff')
            .AddCharacter('\ufa2e')
            .AddCharacter('\ufa2f')
            .AddCharacter('\ufb37')
            .AddCharacter('\ufb3d')
            .AddCharacter('\ufb3f')
            .AddCharacter('\ufb42')
            .AddCharacter('\ufb45')
            .AddCharacter('\ufd90')
            .AddCharacter('\ufd91')
            .AddCharacter('\ufdfe')
            .AddCharacter('\ufdff')
            .AddCharacter('\ufe53')
            .AddCharacter('\ufe67')
            .AddCharacter('\ufe75')
            .AddCharacter('\ufefd')
            .AddCharacter('\ufefe')
            .AddCharacter('\uff00')
            .AddCharacter('\uffc8')
            .AddCharacter('\uffc9')
            .AddCharacter('\uffd0')
            .AddCharacter('\uffd1')
            .AddCharacter('\uffd8')
            .AddCharacter('\uffd9')
            .AddCharacter('\uffe7')
            .AddCharacter('\ufffe')
            .AddCharacter('\uffff');
        }

        #endregion //AddCategoryCn

        #region AddCategoryC

        private static void AddCategoryC(CharacterSet set)
        {
            AddCategoryCc(set);
            AddCategoryCf(set);
            AddCategoryCs(set);
            AddCategoryCo(set);
            AddCategoryCn(set);
        }

        #endregion //AddCategoryC

        #endregion //Utilities
    }
}
