using System;
using System.Collections.Generic;
using System.Threading;


//+ + + + + + + + + + + + 
//+ + + + + + + + + + + + 
//+ + + + + + + + + + + + 
//+ + + x + + + + + + + + 

//console cursor left variable = x axis, top = y axis
int[,] pos = new int[2,2];
for(int i = 0; i < 11; i++){
    string printLine = "";
    for(int ii = 0; ii < 11; ii++){
        printLine = printLine.Insert(printLine.Length, "+ ");
    }
    printLine = printLine.TrimEnd(' ');
    Console.WriteLine(printLine);
}
Console.WriteLine(Console.ReadKey(true).Key);
Console.WriteLine(Console.GetCursorPosition());
pos[1,0] = Console.GetCursorPosition().Left;
pos[1,1] = Console.GetCursorPosition().Top;
Console.SetCursorPosition(10, 5);
pos[0,0] = 10;
pos[0,1] = 5;
Console.Write("x");
Console.SetCursorPosition(pos[1,0], pos[1,1]);
bool ongoing = true;
string typed ="";
while(ongoing){
    ConsoleKey key = Console.ReadKey(true).Key;
    switch((int) key){
        default:
        typed = typed + (char) key;
        Console.Write((char) key);
        pos[1,0]++;
        break;

        case 8:  //Backspace
        typed = typed.Substring(0, typed.Length-1);
        pos[1,0]--;
        Console.SetCursorPosition(pos[1,0], pos[1,1]);
        Console.Write(" ");
        Console.SetCursorPosition(pos[1,0], pos[1,1]);
        break;

        case 13:
        if(typed=="EXIT"){
            ongoing = false;
        }
        Console.SetCursorPosition(0,pos[1,1]);
        Console.WriteLine(typed);
        typed="";
        pos[1,0] = 0;
        pos[1,1]++;
        break;

        case 37:  //left arrow
        Move(pos, -2, new int[]{0,0});
        break;

        case 38:  //up arrow
        Move(pos, -1, new int[]{0,1});
        break;

        case 39:  //right arrow
        Move(pos, 2, new int[]{0,0});
        break;

        case 40:  //down arrow
        Move(pos, 1, new int[]{0,1});
        break;
    }

}

int[,] Move(int[,] position, int movement, int[] location){
    if((position[location[0],location[1]] + movement) < 0){
        return position;
    }
    Console.CursorVisible = false;
    Console.SetCursorPosition(position[0,0], position[0,1]);
    Console.Write("+");
    position[location[0],location[1]] += movement;
    Console.SetCursorPosition(position[0,0], position[0,1]);
    Console.Write("O");
    Console.SetCursorPosition(position[1,0], position[1,1]);
    Console.CursorVisible = true;
    return position;
}
goto end;
end: 

// Console.WriteLine(Console.GetCursorPosition());

PadQuestion("Help No", 45); //Arrays of ints the goes {{x1,y1},{x2,y2},{x3,y3}}
int[] importantPositions = new int[4];  
Console.WriteLine("1---5---1|0--1|5--2|0--2|5--3|0--3|5--4|0--4|5");
TextMove(database.onScreenText.ToArray(), 1);
Console.ReadLine();
database.Clear();
//TODO padquestion is not functioning. Pad lenght calculations are wonky. shit
TextBox("Do you want help?", 45);
TextBox("Yes No Maybe", 45, "question");
string str2 = TextMove(database.onScreenText.ToArray(), 1);

switch(str2.ToLower()){
    default:
        Console.WriteLine("Okay then, have it your way");
        break;

    case "yes":
        Console.WriteLine("You said yes, too bad.");
        break;
    case "no":
        Console.WriteLine("Good, because you ain't getting any.");
        break;
    case "maybe":
        Console.WriteLine("okay?");
        break;
} 
Console.ReadLine();

TextBox("Yes No", 45, "question");
TextBox("Yes No Mayb", 45, "question");
TextBox("1231466", 45, "question");
database.Clear();
string[] testMeny = {"(~1: This is a stress test of the system. This needs to be padded.)", "(~2: It will hopefully)", "(~3: go well.)", "(Lma o)"};
BoxBorder(45);
foreach(string test in testMeny){
    BoxLine(test, 45, "left");
}
BoxBorder(45);
TextMove(database.onScreenText.ToArray(), 0);
Console.ReadLine();

string TextMove((string text, int x, int y)[] textData, int upOrRight){
    int[] metaPos = {0, Console.GetCursorPosition().Left, Console.GetCursorPosition().Top, upOrRight}; //where in the array it is supposed to be, x of it's pos outside of meny e.i where we where before, y of pos, if it's a < > direction meny, or up down meny
    int length = textData.Length-1;                                                                      //upOrRight, 0 = up, 1 = sideways
    bool ongoing = true;
    string text = "";
    void moveCursor(int newPosX, int newPosY, int oldPosX, int oldPosY){
        int[] writePos = {Console.GetCursorPosition().Left, Console.GetCursorPosition().Top}; // pos of cursor where it is supposed to go at the end
        Console.SetCursorPosition(oldPosX-1, oldPosY-1);
        Console.Write(" ");
        Console.SetCursorPosition(newPosX-1, newPosY-1);
        Console.Write(">");
        Console.SetCursorPosition(writePos[0], writePos[1]);
    }

    Console.SetCursorPosition(textData[metaPos[0]].x-1, textData[metaPos[0]].y-1); //set's the cursor to before the first choice
    Console.Write(">");                                                        //writes an ">" to indicate that we're there
    Console.SetCursorPosition(metaPos[1], metaPos[2]);  //moves the cursor back


    while(ongoing){
        ConsoleKey key = Console.ReadKey(true).Key;
        switch((int) key){
            default:
            typed = typed + (char) key;
            Console.Write((char) key);
            metaPos[1]++;
            break;

            case 8:  //Backspace
            if(metaPos[1] > 0){
                typed = typed.Substring(0, typed.Length-1);
                metaPos[1]--;
                Console.SetCursorPosition(metaPos[1], metaPos[2]);
                Console.Write(" ");
                Console.SetCursorPosition(metaPos[1], metaPos[2]);
            }
            break;

            case 13: //Enter
            ongoing = false;
            Console.WriteLine();
            if(typed == ""){
                Console.WriteLine(textData[metaPos[0]].text.ToLower());
                return textData[metaPos[0]].text.ToLower();
            }
            return typed;

            case 37:  //left arrow
            if(metaPos[3] == 1){
                if(metaPos[0]>0){
                    metaPos[0]--;
                    moveCursor(textData[metaPos[0]].x, textData[metaPos[0]].y, textData[metaPos[0]+1].x, textData[metaPos[0]].y);
                }
            }
            break;

            case 38:  //up arrow
            if(metaPos[3] == 0){
                if(metaPos[0]>0){
                    metaPos[0]--;
                    moveCursor(textData[metaPos[0]].x, textData[metaPos[0]].y, textData[metaPos[0]+1].x, textData[metaPos[0]+1].y);
                }
            }
            break;

            case 39:  //right arrow
            if(metaPos[3] == 1){
                if(metaPos[0]<length){
                    metaPos[0]++;
                    moveCursor(textData[metaPos[0]].x, textData[metaPos[0]].y, textData[metaPos[0]-1].x, textData[metaPos[0]].y);
                }
            }
            break;

            case 40:  //down arrow
            if(metaPos[3] == 0){
                if(metaPos[0]<length){
                    metaPos[0]++;
                    moveCursor(textData[metaPos[0]].x, textData[metaPos[0]].y, textData[metaPos[0]-1].x, textData[metaPos[0]-1].y);
                }
            }
            break;
        }
    }
    return text;
}

static void TextBox(string textInput, int windowWidth = 35, string padDir = "equal"){
    BoxBorder(windowWidth);
    BoxLine(textInput, windowWidth, padDir.ToLower());
    BoxBorder(windowWidth);
}
static void BoxBorder(int windowWidth){  //replaces Console.WriteLine("+------------=========------------+"); because of variable window width for non-simple text boxes
    string border = "";
    int thickLength = windowWidth/4;
    if(windowWidth%2 != 0 && thickLength%2 == 0){
        thickLength = thickLength + 1;
    }
    for(int i = 0; i < (windowWidth/2)-(windowWidth/4)/2; i++){
        border = border.Insert(border.Length, "-");
    }
    for(int i = 0; i < thickLength; i++){
        border = border.Insert(border.Length, "=");
    }
    while(border.Length<windowWidth){
        border = border.Insert(border.Length, "-");
    }
    border = border.Remove(0,1);
    border = border.Insert(0, "+");
    border = border.Remove(border.Length-1, 1);
    border = border.Insert(border.Length, "+");
    Console.WriteLine(border);
}
static void BoxLine(string textInput, int windowWidth = 35, string padDir = "right"){  // needed because of special boxes
    int weDied = 0;  //if we get stuck in an endless loop, this should stop it eventually.
    int splitTheWord = 0;
    int wordCount = 0;  //what word we on
    bool ongoing = true;
    bool force = false;
    List<string> text = new List<string>();
    int[] choices = new int[2];
    string[] textWIP = textInput.Split(" ");
    string textInternal = "";
    while(ongoing){
        void AddTextInternal(){
            if(textInternal.Length != 0){
                textInternal = textInternal.TrimStart(' ');
                if(text.Count > 0){
                    if(text[text.Count-1].Contains(':') && splitTheWord == -1){
                        for(int i = 0; i < text[text.Count-1].Split(' ')[0].Length + 1; i++){//That argument is one of the most dusgusting things i have ever written
                            textInternal = textInternal.Insert(0, " ");
                        }
                        splitTheWord++;
                    }
                }
                text.Add(textInternal);
            }
        }
        if(textWIP[wordCount].Contains("(")){  //Handles the UI elements, mainly keeping track of where it is needed, and what text
            if(textWIP[wordCount][1]=='~'){
                textWIP[wordCount] = textWIP[wordCount].Substring(1);
                choices[1] = text.Count;
                choices[0] = wordCount;
                database.onScreenTextPrime.Add(new (textWIP[wordCount].Substring(1), choices[0], choices[1]));
            }
            int wordCount1 = wordCount+1;      
                textWIP[wordCount] = textWIP[wordCount].Substring(1);
            while(!textWIP[wordCount].Contains(")")){
                textWIP[wordCount] = textWIP[wordCount].Insert(textWIP[wordCount].Length, " "+textWIP[wordCount1]);
                textWIP[wordCount1] = textWIP[wordCount1].Insert(0, "½");
                wordCount1++;
            }
            textWIP[wordCount] = textWIP[wordCount].Remove(textWIP[wordCount].Length-1, 1);
            force = true;
        }
        // if(textInternal.Length == 0){  //if it's the first "word"
        //     textInternal = textInternal.Insert(0, textWIP[wordCount]);
        //     wordCount++;
        // } else {  //otherwise it adds an " " at the beggining of a word.
        if(!textWIP[wordCount].Contains("½")){
            textInternal = textInternal.Insert(textInternal.Length, " "+textWIP[wordCount]);
        }
        wordCount++;
        //}
        
        if(textInternal.Length > windowWidth-4){  //Checks if the current line is too big/ bigger than the wanted window width
            wordCount--;
            if(wordCount < textWIP.Length-1){ // to make sure no array out of bounds exceptions trigger. and i'm lazy and this works
                if(textWIP[wordCount+1].Contains("½")){
                    splitTheWord++;
                    if(splitTheWord>10){
                        force = true;
                    }
                    if(splitTheWord>15){
                        string[] tempText = textWIP[wordCount].Split(" ");
                        for(int i = 0; i < tempText.Length; i++){
                            textWIP[wordCount+i] = tempText[i];
                        }
                        splitTheWord = -2;
                    }
                }
            }
            weDied++;
            if(splitTheWord == -2){
                splitTheWord++;
                textInternal = "";
            } else 
            textInternal = textInternal.Remove(textInternal.Length - textWIP[wordCount].Length - 1);
            AddTextInternal();
            textInternal = "";
            // Console.WriteLine("line"+text.Count+" is finished");
        }
        if(wordCount == textWIP.Length){ // checks if it is the last word of the text input
            // Console.WriteLine("last line finished");
            AddTextInternal();
            ongoing=false;
        } else if(textInternal.Contains(".") || force || textInternal.Contains("?")){
            if(!(textInternal.Length > windowWidth-4)){
                AddTextInternal();
                textInternal = "";
            } else {
                splitTheWord++;
            }
            force = false;
        }
        if(weDied > 500){
            Console.WriteLine("The textbox function has stopped working due to");
            Console.WriteLine("a certain word not fitting within the allowed box size");
            Console.WriteLine($"Word: \"{textWIP[wordCount]}\" Word Length: {textWIP[wordCount].Length} Box Size: {windowWidth}");
            Console.ReadLine();
            return;
        }
        weDied++;
    }
    //let's the program know where the fuck it's supposed to put the indicator + what is there.
    //equal should just use question if it requires input instead. And Question doesn't require this
    for(int i = 0; i < database.onScreenTextPrime.Count; i++){
        if(padDir == "right"){
            string word = database.onScreenTextPrime[i].str;
            int xCord = text[database.onScreenTextPrime[i].rowInText].IndexOf(word);
            database.onScreenText.Add((word.Split(' ')[0], xCord+2, Console.GetCursorPosition().Top + database.onScreenTextPrime[i].rowInText + 1));
            database.onScreenTextPrime.RemoveAt(i);  //xCord needs to be +2 since we're adding 2 characters to the beggining of the outputted string
        }
        else if(padDir == "left"){
            string word = database.onScreenTextPrime[i].str;
            int xCord = text[database.onScreenTextPrime[i].rowInText].IndexOf(word);
            database.onScreenText.Add((word.Split(' ')[0], xCord+2, Console.GetCursorPosition().Top + database.onScreenTextPrime[i].rowInText + 1));
            database.onScreenTextPrime.RemoveAt(i);
        }
    }


    switch(padDir){
        case "right":
            foreach(string output in text){
                Console.WriteLine("| "+output.PadRight(windowWidth-4)+" |");
            }
            break;
        
        case "left":
            foreach(string output in text){
                Console.WriteLine("| "+output.PadLeft(windowWidth-4)+" |");
            }
            break;
        case "question":
            foreach(string output in text){
                PadQuestion(output, windowWidth);
            }
            break;
        case "equal":
            foreach(string output in text){
                Console.WriteLine("| "+PadEqual(output, windowWidth-4)+" |");
            }
            break;
        
        default:
            Console.WriteLine("wrong format type given");
            Console.WriteLine("| "+text+" |");
            break;
    }
}
static string PadEqual(string str, int desiredLength){   // if i have padRight and padLeft, why cant i have PadEqual
    string paddedString=str.PadLeft(((desiredLength-str.Length)/2)+str.Length);//Pads the left side, half of the total pad
    return paddedString.PadRight(desiredLength);                               //Pads the right side, other half of the total pad
}


static void PadQuestion(string str, int desiredLength){
    List<int[]> positions = new List<int[]>();
    List<string> choises = new List<string>(); // the different choises being presented to the player.
    foreach(string word in str.Split(' ')){
        if(word[0] == '~') choises.Add(word.Remove('~'));
    }
    int spaces = 0;
    foreach(char ch in str){
        if(ch == ' ') spaces++;
    }
    string paddedString = "";
    string[] words = str.Split(" ");
    int amount = words.Length+1; //amount of pads
    int[] pads = new int[amount];  // the length of different pads
    desiredLength -= str.Length - spaces + 4;
    int rest = desiredLength % amount;
    // if(desiredLength % amount != 0){    //kolla pappers documentation för detta segment, gud hjälp den som försöker förstå den. //vart är papper documentationen?
    //     for(int i = 1; i < rest; i++){ //for loop som listar ut hur stor resten av divitionen är genom att tästa alla möjliga resultat. lmao det finns änklare sätt
    //         if(rest % i == 0){  //när den hittar rätt nummer
    //             if(i % 2 == 0){  //om överskottet är dividerbart med 2 så sätter vi överskottet i kanterna av lådan
    //                 for(int ii = 0; ii < i/2; ii++){
    //                     pads[ii]++;
    //                     pads[pads.Length-ii]++;
    //                 }
    //             } else {  // om den inte är det sätter vi den i mitten
    //                 for(int ii = 0; ii < i; ii++){
    //                     pads[(pads.Length/2)-(i/2)+ii]++;
    //                 }
    //             }    
    //         }
    //     }  ddenna bit kod funkade aldrig.
    // }
    if(rest > 0){
        if(rest % 2 != 0){
            if(amount > 2){
                pads[(amount/2)]++;
            }
        }
        pads[0] += rest/2;
        pads[amount-1] += rest/2;
    }
    int consoleTop = Console.GetCursorPosition().Top;
    for(int i = 0; i < pads.Length; i++){
        pads[i] += desiredLength/amount;
    }
    for(int i = 0; i < words.Length+1; i++){
        string padding = "";
        for(int ii = 0; ii < pads[i]; ii++){
            padding = padding + " ";
        }
        if(i == pads.Length-1){
            paddedString = paddedString + padding;
        } else {
            database.onScreenText.Add((words[i], paddedString.Length + padding.Length+2, consoleTop+1)); //x position of word, y position of word
            paddedString = paddedString + padding + words[i];
        }
    }
    Console.WriteLine("| "+paddedString+" |");

    //return positions.ToArray(); Could do this, but then i'd have to use jagged arrays so no thanks
    //"use jagged arrays" he said. "lol" said god. "lmao"
}
