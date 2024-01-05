﻿namespace GDS.Api.Model
{
    public class Profile(string name, DateTime created, DateTime lastChanged, string imgBase64 = "")
    {
        public string Name { get; set; } = name;
        public string ImgBase64 { get; set; } = !string.IsNullOrEmpty(imgBase64) ? imgBase64 : @"iVBORw0KGgoAAAANSUhEUgAABBoAAASICAIAAAAyEDtAAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwwAADsMBx2+oZAAAFRNJREFUeF7tx6ENwDAABLHsP24WaPihV7ElE5/vAgAA/NEDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAox4AAGDUAwAAjHoAAIBRDwAAMOoBAABGPQAAwKgHAAAY9QAAAKMeAABg1AMAAIx6AACAUQ8AADDqAQAARj0AAMCoBwAAGPUAAACjHgAAYNQDAACMegAAgFEPAAAw6gEAAEY9AADAqAcAABj1AAAAk3seho/2G6xatA8AAAAASUVORK5CYII=";
        public List<Card> Cards { get; set; } = new List<Card>();
        public string FileName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = created;
        public DateTime LastChanged {  get; set; } = lastChanged;
    }
    public class ProfileEncrypted(string name, string imgBase64, byte[] cards, DateTime created, DateTime lastChanged)
    {
        public string Name { get; set; } = name;
        public string ImgBase64 { get; set; } = imgBase64;
        public DateTime CreatedOn { get; set; } = created;
        public DateTime LastChanged { get; set; } = lastChanged;

        public byte[] Cards { get; set; } = cards;
    }
    public class Card(Guid id, string name, string imgBase64 = "")
    {
        public Guid Id { get; set; } = id;
        public string ImgBase64 { get; set; } = imgBase64;
        public string Name { get; set; } = name;
        public List<Box> Boxes { get; set;} = new List<Box>();
    }
    public class Box(Guid id, string name, bool isSecret, string data)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public bool IsSecret { get; set; } = isSecret;
        public string Data { get; set; } = data;
    }
}
