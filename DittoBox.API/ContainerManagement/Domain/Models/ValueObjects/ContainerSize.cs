namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public class ContainerSize(
        string name,
        int internalLength,
        int internalWidth,
        int internalHeight,
        int externalLength,
        int externalWidth,
        int externalHeight,
        int volume = 0
            )
    {
        public int Id { get; set; }
        public string SizeName { get; set; } = name;
        /// <summary>
        /// External length in millimeters
        /// </summary>
        public int ExternalLength { get; set; } = externalLength;
        /// <summary>
        /// External width in millimeters
        /// </summary>
        public int ExternalWidth { get; set; } = externalWidth;
        /// <summary>
        /// External height in millimeters
        /// </summary>
        public int ExternalHeight { get; set; } = externalHeight;
        /// <summary>
        /// Internal length in millimeters
        /// </summary>
        public int InternalLength { get; set; } = internalLength;
        /// <summary>
        /// Internal width in millimeters
        /// </summary>
        public int InternalWidth { get; set; } = internalWidth;
        /// <summary>
        /// Internal height in millimeters
        /// </summary>
        public int InternalHeight { get; set; } = internalHeight;
        // Volume in cubic centimeters
        public int Volume { get; set; } = volume == 0 ?
            (internalLength / 10) * (internalWidth / 10) * (internalHeight / 10) : volume;
    }
}
