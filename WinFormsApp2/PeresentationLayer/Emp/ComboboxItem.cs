﻿namespace WinFormsApp2.PeresentationLayer.Emp
{
    public class ComboboxItem
    {
        public string? Text { get; set; }
        public object? Value { get; set; }

        public override string ToString()
        {
            return Text!;
        }
    }
}