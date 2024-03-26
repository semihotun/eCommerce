using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Core.Extension
{
    public static class SyntaxTreeExtension
    {
        public static string FormatCsharpDocumentCode(this string text)
        {
            return CSharpSyntaxTree.ParseText(text)
                .GetCompilationUnitRoot()
                .NormalizeWhitespace()
                .ToFullString();
        }
    }
}
