using System;

namespace Mine.Models
{
    /// <summary>
    /// Items for the Characters and Monsters to use
    /// </summary>
    public class ItemModel
    {
        // The ID for the Item
        public string Id { get; set; }

        // The Display text for the Item
        public string Text { get; set; }

        // The Description of the Item
        public string Description { get; set; }

        // The Value of the Item
        public int Value { get; set; } = 0;
    }
}