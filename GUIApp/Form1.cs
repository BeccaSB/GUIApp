using Board;

namespace GUIApp
{
    public partial class Form1 : Form
    {
        // this class is in reference to GameBoard class, where  the values are stored.
      static GameBoard myGameBoard = new GameBoard(8);

        // Buttons
        public Button[,] btnGraph = new Button[myGameBoard.Dimension, myGameBoard.Dimension];
        public Form1()
        {
            InitializeComponent();
            populateGraph();
        }

        private void populateGraph()
        {
            // creating button 
            int buttonDimension = panel1.Width / myGameBoard.Dimension;

            //Square shape button
            panel1.Height = panel1.Width;

            for (int i = 0; i < myGameBoard.Dimension; i++)
            {
                for (int j =0; j < myGameBoard.Dimension; j++)
                {
                    btnGraph[i, j] = new Button();

                    btnGraph[i,j ].Height= buttonDimension;
                    btnGraph[i,j].Width= buttonDimension;

                    // Click event
                    btnGraph[i, j].Click += Graph_Button_Click;
                    

                    //Add the button into the panel
                    panel1.Controls.Add(btnGraph[i,j]);
                    btnGraph[i, j].Location = new Point(buttonDimension * i, buttonDimension * j);

                    btnGraph[i, j].Text = i.ToString() + "" + j.ToString();
                    btnGraph[i, j].Tag = new Point(i, j);
                    btnGraph[i, j].BackColor = Color.Black;


                }
            }
        }

        private void Graph_Button_Click(object sender, EventArgs e)
        {
            // get the rank and file for button clicked
            Button clickedButton = (Button) sender;
            Point location = (Point) clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

           Square currentSquare = myGameBoard.theGraph[x, y];

            // determine valid moves
            myGameBoard.ShowValidMove(currentSquare, comboBox1.Text);
            currentSquare.Occupied= true;

            
            updateButtonLabel();

            //Text button
            for (int i = 0; i < myGameBoard.Dimension; i++)
            {
                for (int j = 0; j < myGameBoard.Dimension; j++)
                {
                    btnGraph[i, j].BackColor =default(Color);

                    
                    }
                }
                clickedButton.BackColor = Color.Yellow;
             }
        private void updateButtonLabel()
        {
            for (int i = 0; i < myGameBoard.Dimension; i++)
            {
                for (int j = 0; j < myGameBoard.Dimension; j++)
                {
                    btnGraph[i, j].Text = "";
                    if (myGameBoard.theGraph[i, j].ValidMove == true) btnGraph[i, j].Text = "Valid Move";
                    
                    if (myGameBoard.theGraph[i,j].Occupied == true)
                    {
                        btnGraph[i, j].Text = comboBox1.Text;

                    }
                }
            }



        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

        
}