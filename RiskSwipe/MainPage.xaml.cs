using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RiskSwipe
{
    public class boardSlot
    {
        public int x { get; set; }
        public int y { get; set; }
        public int units { get; set; }
        public string ownedBy { get; set; }

        public boardSlot(int xIn, int yIn, int unitsIn, string ownedByIn)
        {
            x = xIn;
            y = yIn;
            units = unitsIn;
            ownedBy = ownedByIn;
        }
    }

    public partial class MainPage : ContentPage
    {
        public int Home;
        public int Target;
        public string currentTurn = "Red";

        public Color red = Color.FromRgb(166, 31, 52);
        public Color blue = Color.FromRgb(68, 169, 211);
        public Color green = Color.FromRgb(85, 254, 115);

        public List<boardSlot> VirtualBoard = new List<boardSlot> { };

        public void init()
        {
            //spawn virtual world
            for (int x = 0; x < 5; x++)
            {
                //rows
                for (int y = 0; y < 5; y++)
                {
                    //columns
                    boardSlot newBoardSlot = new boardSlot(x, y, 0, "None");
                    VirtualBoard.Add(newBoardSlot);
                }
            }

            //set ownership red
            VirtualBoard[0].units = 2;
            VirtualBoard[0].ownedBy = "Red";

            //set ownership blue
            VirtualBoard[24].units = 2;
            VirtualBoard[24].ownedBy = "Blue";

            //setting scoreboard
            //redScore.Text = "Red Score: 1";
            //blueScore.Text = "Blue Score: 1";

            //runs a set for the board colors
            SetBoard();
        }

        public void SetTile(int x, int y, Color color)
        {
            if (x == 0)
            {
                if (y == 0)
                {
                    Box0.Color = color;
                    Box0Units.Text = VirtualBoard[0].units.ToString();
                }
                if (y == 1)
                {
                    Box1.Color = color;
                    Box1Units.Text = VirtualBoard[1].units.ToString();
                }
                if (y == 2)
                {
                    Box2.Color = color;
                    Box2Units.Text = VirtualBoard[2].units.ToString();
                }
                if (y == 3)
                {
                    Box3.Color = color;
                    Box3Units.Text = VirtualBoard[3].units.ToString();
                }
                if (y == 4)
                {
                    Box4.Color = color;
                    Box4Units.Text = VirtualBoard[4].units.ToString();
                }
            }
            if (x == 1)
            {
                if (y == 0)
                {
                    Box5.Color = color;
                    Box5Units.Text = VirtualBoard[5].units.ToString();
                }
                if (y == 1)
                {
                    Box6.Color = color;
                    Box6Units.Text = VirtualBoard[6].units.ToString();
                }
                if (y == 2)
                {
                    Box7.Color = color;
                    Box7Units.Text = VirtualBoard[7].units.ToString();
                }
                if (y == 3)
                {
                    Box8.Color = color;
                    Box8Units.Text = VirtualBoard[8].units.ToString();
                }
                if (y == 4)
                {
                    Box9.Color = color;
                    Box9Units.Text = VirtualBoard[9].units.ToString();
                }
            }
            if (x == 2)
            {
                if (y == 0)
                {
                    Box10.Color = color;
                    Box10Units.Text = VirtualBoard[10].units.ToString();
                }
                if (y == 1)
                {
                    Box11.Color = color;
                    Box11Units.Text = VirtualBoard[11].units.ToString();
                }
                if (y == 2)
                {
                    Box12.Color = color;
                    Box12Units.Text = VirtualBoard[12].units.ToString();
                }
                if (y == 3)
                {
                    Box13.Color = color;
                    Box13Units.Text = VirtualBoard[13].units.ToString();
                }
                if (y == 4)
                {
                    Box14.Color = color;
                    Box14Units.Text = VirtualBoard[14].units.ToString();
                }
            }
            if (x == 3)
            {
                if (y == 0)
                {
                    Box15.Color = color;
                    Box15Units.Text = VirtualBoard[15].units.ToString();
                }
                if (y == 1)
                {
                    Box16.Color = color;
                    Box16Units.Text = VirtualBoard[16].units.ToString();
                }
                if (y == 2)
                {
                    Box17.Color = color;
                    Box17Units.Text = VirtualBoard[17].units.ToString();
                }
                if (y == 3)
                {
                    Box18.Color = color;
                    Box18Units.Text = VirtualBoard[18].units.ToString();
                }
                if (y == 4)
                {
                    Box19.Color = color;
                    Box19Units.Text = VirtualBoard[19].units.ToString();
                }
            }
            if (x == 4)
            {
                if (y == 0)
                {
                    Box20.Color = color;
                    Box20Units.Text = VirtualBoard[20].units.ToString();
                }
                if (y == 1)
                {
                    Box21.Color = color;
                    Box21Units.Text = VirtualBoard[21].units.ToString();
                }
                if (y == 2)
                {
                    Box22.Color = color;
                    Box22Units.Text = VirtualBoard[22].units.ToString();
                }
                if (y == 3)
                {
                    Box23.Color = color;
                    Box23Units.Text = VirtualBoard[23].units.ToString();
                }
                if (y == 4)
                {
                    Box24.Color = color;
                    Box24Units.Text = VirtualBoard[24].units.ToString();
                }
            }
        }

        public void SetBoard()
        {
            int x = 0;
            int y = 0;
            
            foreach (boardSlot slot in VirtualBoard)
            {
                if (slot.ownedBy == "Red")
                {
                    x = slot.x;
                    y = slot.y;
                    SetTile(x, y, red);
                }
                if (slot.ownedBy == "Blue")
                {
                    x = slot.x;
                    y = slot.y;
                    SetTile(x, y, blue);
                }
                if (slot.ownedBy == "None")
                {
                    x = slot.x;
                    y = slot.y;
                    SetTile(x, y, green);
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            init();
        }

        public void SetTarget(string Direction, int Home)
        {
            int offSet = 0;

            //Debug.WriteLine(Direction);

            switch (Direction)
            {
                case "Left":
                    offSet = 1;
                    Target = Home - offSet;
                    break;
                case "Right":
                    offSet = 1;
                    Target = Home + offSet;
                    break;
                case "Up":
                    offSet = 5;
                    Target = Home - offSet;
                    break;
                case "Down":
                    offSet = 5;
                    Target = Home + offSet;
                    break;
            }

            //Debug.WriteLine("Target: " + Target + " Home: " + Home + " Off Set: " + offSet);

            //home.Text = "Home: " + Home.ToString();
            //target.Text = "Target: " + Target.ToString();

            CheckMove();
        }

        public bool isEven(int home)
        {
            if (home % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeOverSquare()
        {
            int resultHome = 0;
            int resultTarget = 0;

            if (currentTurn == "Red")
            {
                VirtualBoard[Target].ownedBy = "Red";

                if (isEven(VirtualBoard[Home].units))
                {
                    resultHome = VirtualBoard[Home].units / 2;
                    resultTarget = VirtualBoard[Home].units / 2;
                }
                else
                {
                    //Debug.WriteLine("Home: " + resultHome + " Target: " + resultTarget);
                    resultHome = (VirtualBoard[Home].units / 2) + 1;
                    resultTarget = VirtualBoard[Home].units / 2;
                }

                VirtualBoard[Home].units = resultHome;
                VirtualBoard[Target].units = resultTarget;

                SetBoard();
            }
            else if(currentTurn == "Blue")
            {
                VirtualBoard[Target].ownedBy = "Blue";

                if (isEven(VirtualBoard[Home].units))
                {
                    resultHome = VirtualBoard[Home].units / 2;
                    resultTarget = VirtualBoard[Home].units / 2;
                }
                else
                {
                    //Debug.WriteLine("Home: " + resultHome + " Target: " + resultTarget);
                    resultHome = (VirtualBoard[Home].units / 2) + 1;
                    resultTarget = VirtualBoard[Home].units / 2;
                }

                VirtualBoard[Home].units = resultHome;
                VirtualBoard[Target].units = resultTarget;

                SetBoard();
            }
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void Battle()
        {
            //make two tiles fight
            //render a winner
            //edit map for win or loss
            int resultHome = 0;
            int resultTarget = 0;
            int winCondition = 0;

            if (isEven(VirtualBoard[Home].units))
            {
                resultHome = VirtualBoard[Home].units / 2;

                resultTarget = VirtualBoard[Target].units - (VirtualBoard[Home].units / 2);
                
                if (resultTarget > winCondition)
                {
                    //assume win
                    Debug.WriteLine("Won" + VirtualBoard[Target].units);
                    if (VirtualBoard[Target].units - 1 == 1)
                    {
                        int random = RandomNumber(0, 9);
                        Debug.WriteLine("Should be running random win" + random);
                        if (random < 4)
                        {
                            //assume win
                            Debug.WriteLine("Won");
                        }
                        else
                        {
                            //assume loss
                            Debug.WriteLine("Loss");
                            if (currentTurn == "Red")
                            {
                                VirtualBoard[Target].ownedBy = "Red";
                            }
                            else if (currentTurn == "Blue")
                            {
                                VirtualBoard[Target].ownedBy = "Blue";
                            }

                            resultTarget = 1;
                        }
                    }
                }
                else if (resultTarget < winCondition)
                {
                    //assume loss
                    Debug.WriteLine("Loss");
                    if (currentTurn == "Red")
                    {
                        VirtualBoard[Target].ownedBy = "Red";
                    }
                    else if (currentTurn == "Blue")
                    {
                        VirtualBoard[Target].ownedBy = "Blue";
                    }

                    resultTarget = resultTarget * -1;
                }
            }
            else
            {
                //Debug.WriteLine("Home: " + resultHome + " Target: " + resultTarget);
                resultHome = (VirtualBoard[Home].units / 2) + 1;

                resultTarget = VirtualBoard[Target].units - (VirtualBoard[Home].units / 2);

                if (resultTarget > winCondition)
                {
                    //assume win
                    Debug.WriteLine("Won" + VirtualBoard[Target].units);
                    if (VirtualBoard[Target].units - 1 == 1)
                    {
                        int random = RandomNumber(0, 9);
                        Debug.WriteLine("Should be running random win" + random);
                        if (random < 4)
                        {
                            //assume win
                            Debug.WriteLine("Won");
                        }
                        else
                        {
                            //assume loss
                            Debug.WriteLine("Loss");
                            if (currentTurn == "Red")
                            {
                                VirtualBoard[Target].ownedBy = "Red";
                            }
                            else if (currentTurn == "Blue")
                            {
                                VirtualBoard[Target].ownedBy = "Blue";
                            }

                            resultTarget = 1;
                        }
                    }
                }
                else if (resultTarget < winCondition)
                {
                    //assume loss
                    Debug.WriteLine("Loss");
                    if (currentTurn == "Red")
                    {
                        VirtualBoard[Target].ownedBy = "Red";
                    }
                    else if (currentTurn == "Blue")
                    {
                        VirtualBoard[Target].ownedBy = "Blue";
                    }

                    resultTarget = resultTarget * -1;
                }
            }

            VirtualBoard[Home].units = resultHome;
            VirtualBoard[Target].units = resultTarget;

            SetBoard();
        }

        public void MoveTroops()
        {
            int resultHome = 0;
            int resultTarget = 0;

            if (isEven(VirtualBoard[Home].units))
            {
                resultHome = VirtualBoard[Home].units / 2;
                resultTarget = VirtualBoard[Target].units + VirtualBoard[Home].units / 2;
            }
            else
            {
                //Debug.WriteLine("Home: " + resultHome + " Target: " + resultTarget);
                resultHome = (VirtualBoard[Home].units / 2) + 1;
                resultTarget = VirtualBoard[Target].units + VirtualBoard[Home].units / 2;
            }

            VirtualBoard[Home].units = resultHome;
            VirtualBoard[Target].units = resultTarget;

            SetBoard();
        }

        public void CheckMove()
        {
            bool inBounds = true;

            if (Target <= -1 || Target >= 25)
            {
                inBounds = false;
            }

            //Debug.WriteLine("Here is the target number: " + Target + " bounds state: " + inBounds);

            if (inBounds)
            {
                if (VirtualBoard[Home].units > 1)
                {
                    if (currentTurn == "Red")
                    {
                        if (VirtualBoard[Home].ownedBy == "Red")
                        {
                            if (VirtualBoard[Target].ownedBy == "None")
                            {
                                TakeOverSquare();
                            }
                            else if (VirtualBoard[Target].ownedBy == "Red")
                            {
                                MoveTroops();
                            }
                            else
                            {
                                Battle();
                            }
                        }
                    }
                    if (currentTurn == "Blue")
                    {
                        if (VirtualBoard[Home].ownedBy == "Blue")
                        {
                            if (VirtualBoard[Target].ownedBy == "None")
                            {
                                TakeOverSquare();
                            }
                            else if (VirtualBoard[Target].ownedBy == "Blue")
                            {
                                MoveTroops();
                            }
                            else
                            {
                                Battle();
                            }
                        }
                    }
                }
            }
        }

        void OnSwiped0(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 0: {e.Direction.ToString()}";
            Home = 0;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped1(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 1: {e.Direction.ToString()}";
            Home = 1;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped2(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 2: {e.Direction.ToString()}";
            Home = 2;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped3(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 3: {e.Direction.ToString()}";
            Home = 3;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped4(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 4: {e.Direction.ToString()}";
            Home = 4;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped5(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 5: {e.Direction.ToString()}";
            Home = 5;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped6(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 6: {e.Direction.ToString()}";
            Home = 6;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped7(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 7: {e.Direction.ToString()}";
            Home = 7;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped8(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 8: {e.Direction.ToString()}";
            Home = 8;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped9(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 9: {e.Direction.ToString()}";
            Home = 9;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped10(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 10: {e.Direction.ToString()}";
            Home = 10;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped11(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 11: {e.Direction.ToString()}";
            Home = 11;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped12(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 12: {e.Direction.ToString()}";
            Home = 12;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped13(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 13: {e.Direction.ToString()}";
            Home = 13;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped14(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 14: {e.Direction.ToString()}";
            Home = 14;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped15(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 15: {e.Direction.ToString()}";
            Home = 15;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped16(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 16: {e.Direction.ToString()}";
            Home = 16;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped17(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 17: {e.Direction.ToString()}";
            Home = 17;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped18(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 18: {e.Direction.ToString()}";
            Home = 18;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped19(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 19: {e.Direction.ToString()}";
            Home = 19;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped20(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 20: {e.Direction.ToString()}";
            Home = 20;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped21(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 21: {e.Direction.ToString()}";
            Home = 21;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped22(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 22: {e.Direction.ToString()}";
            Home = 22;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped23(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 23: {e.Direction.ToString()}";
            Home = 23;
            SetTarget(e.Direction.ToString(), Home);
        }

        void OnSwiped24(object sender, SwipedEventArgs e)
        {
            //label.Text = $"You swiped 24: {e.Direction.ToString()}";
            Home = 24;
            SetTarget(e.Direction.ToString(), Home);
        }

        public void PassiveResources()
        {
            if (currentTurn == "Red")
            {
                foreach (boardSlot slot in VirtualBoard)
                {
                    if (slot.ownedBy == "Blue")
                    {
                        slot.units += 1;
                    }
                }
            }

            if (currentTurn == "Blue")
            {
                foreach (boardSlot slot in VirtualBoard)
                {
                    if (slot.ownedBy == "Red")
                    {
                        slot.units += 1;
                    }
                }
            }

            SetBoard();
        }

        public void EndTurn_Clicked(object sender, EventArgs e)
        {
            if (currentTurn == "Red")
            {
                currentTurn = "Blue";
                turn.Text = "Turn: Blue";
                //Debug.WriteLine("Blues turn");
            }
            else if (currentTurn == "Blue")
            {
                currentTurn = "Red";
                turn.Text = "Turn: Red";
                //Debug.WriteLine("Reds turn");
            }

            Home = 0;
            Target = 0;

            PassiveResources();
            CheckWin();
        }

        public void CheckWin()
        {
            int tallyBlue = 0;
            int tallyRed = 0;
            foreach (boardSlot slot in VirtualBoard)
            {
                if (slot.ownedBy == "Red")
                {
                    tallyRed += 1;
                }
                if (slot.ownedBy == "Blue")
                {
                    tallyBlue += 1;
                }
            }

            if (tallyBlue == 0)
            {
                turn.Text = "Red Wins";
            }

            if(tallyRed == 0)
            {
                turn.Text = "Blue Wins";
            }
        }
    }
}
