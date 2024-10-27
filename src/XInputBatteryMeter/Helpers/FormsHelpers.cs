namespace XInputBatteryMeter.Helpers;

/// <summary>
/// A class that provides extension methods for working with <see cref="System.Windows.Forms" />.
/// </summary>
public static class FormsHelpers
{
    /// <summary>
    /// Returns the first <see cref="ToolStripItem" /> with the specified name.
    /// </summary>
    /// <param name="source">The source collection of <see cref="ToolStripItem" /> objects.</param>
    /// <param name="name">The name of the <see cref="ToolStripItem" /> to find.</param>
    /// <returns>The first <see cref="ToolStripItem" /> with the specified name, or <see langword="null" /> if not found.</returns>
    public static ToolStripItem? FirstWithName(this IEnumerable<ToolStripItem> source, string name)
    {
        return source.FirstOrDefault(x => x.Name?.Equals(name) ?? false) as ToolStripMenuItem;
    }

    /// <summary>
    ///  Returns the first <see cref="ToolStripMenuItem" /> with the specified name.
    /// </summary>
    /// <param name="source">The source collection of <see cref="ToolStripItem" /> objects.</param>
    /// <param name="name">The name of the <see cref="ToolStripMenuItem" /> to find.</param>
    /// <returns>The first <see cref="ToolStripMenuItem" /> with the specified name, or <see langword="null" /> if not found.</returns>
    public static ToolStripMenuItem? FirstMenuItemWithName(this IEnumerable<ToolStripItem> source, string name)
    {
        return source.FirstWithName(name) as ToolStripMenuItem;
    }
}
