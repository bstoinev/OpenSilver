﻿

/*===================================================================================
* 
*   Copyright (c) Userware/OpenSilver.net
*      
*   This file is part of the OpenSilver Runtime (https://opensilver.net), which is
*   licensed under the MIT license: https://opensource.org/licenses/MIT
*   
*   As stated in the MIT license, "the above copyright notice and this permission
*   notice shall be included in all copies or substantial portions of the Software."
*  
\*====================================================================================*/

using DotNetForHtml5.Core;
using System;
using System.Windows.Markup;

#if MIGRATION
namespace System.Windows
{
    [SupportsDirectContentViaTypeFromStringConverters]
    public sealed partial class TextDecorationCollection
    {
        static TextDecorationCollection()
        {
            TypeFromStringConverters.RegisterConverter(typeof(TextDecorationCollection), INTERNAL_ConvertFromString);
        }

        internal TextDecorationCollection() { }

        internal TextDecoration Decoration { get; set; }

        internal static object INTERNAL_ConvertFromString(string tdStr)
        {
            switch ((tdStr ?? string.Empty).ToLower())
            {
                case "underline":
                    return TextDecorations.Underline;
                case "strikethrough":
                    return TextDecorations.Strikethrough;
                case "overline":
                    return TextDecorations.OverLine;
                //case "baseline":
                //    return TextDecorations.Baseline;
                case "none":
                    return null;
                default:
                    throw new InvalidOperationException(
                        string.Format("Failed to create a '{0}' from the text '{1}'", 
                                      typeof(TextDecorationCollection).FullName, tdStr));
            }
        }

        internal string ToHtmlString()
        {
            if (Decoration != null)
            {
                switch (Decoration.Location)
                {
                    case TextDecorationLocation.Underline:
                        return "underline";
                    case TextDecorationLocation.Strikethrough:
                        return "line-through";
                    case TextDecorationLocation.OverLine:
                        return "overline";
                    //case TextDecorationLocation.Baseline:
                    //    break;
                }
            }

            return string.Empty;
        }
    }

    internal sealed partial class TextDecoration
    {
        internal TextDecoration(TextDecorationLocation location)
        {
            this.Location = location;
        }

        internal TextDecorationLocation Location { get; private set; }
    }
}
#endif
