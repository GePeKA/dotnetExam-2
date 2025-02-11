using System.Reflection;

namespace RatingService.Features.Helpers;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
