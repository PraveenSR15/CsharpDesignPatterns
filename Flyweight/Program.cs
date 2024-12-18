using Flyweight;

var texts = "abba";

var charFactory = new CharacterFactory();

var charObj = charFactory.GetCharacter(texts[0]);
charObj?.Draw("Calibri", 10);

charObj = charFactory.GetCharacter(texts[1]);
charObj?.Draw("Times New Roman", 15);

charObj = charFactory.GetCharacter(texts[2]);
charObj?.Draw("Arial", 5);

charObj = charFactory.GetCharacter(texts[3]);
charObj?.Draw("Comic Sans", 13);


var paragraph = charFactory.CreateParagraph(new List<ICharacter>() { charObj }, 1);
paragraph.Draw("Arial", 19);

Console.ReadKey();