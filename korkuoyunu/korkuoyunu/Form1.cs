using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace korkuoyunu
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharecters();
            



        }
        public void tabloyenile()
        {
            plyrhitlbl.Text = "Player Hit Point";
            bthitlbl.Text = "Bat Hit Point";
            ghsthitlbl.Text = "Ghost Hit Point";
            ghlhitlbl.Text = "Ghoul Hit Point";
        }
        private Game game;
        private Random random = new Random();
        public void UpdateCharecters()
        {
            player.Location = game.PlayerLocation;
            plyrhitlbl.Text = game.PlayerHitPoints.ToString();
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;
            bat.Visible = false;
            ghost.Visible = false;
            ghoul.Visible = false;
           
            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    bthitlbl.Text = enemy.HitPoints.ToString();
                    bat.Visible = true;
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost )
                {
                    ghost.Location = enemy.Location;
                    ghsthitlbl.Text = enemy.HitPoints.ToString();
                    ghost.Visible = true;
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghlhitlbl.Text = enemy.HitPoints.ToString();
                    ghoul.Visible = true;
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }
            
            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;
            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword;
                    break;
                case "Bow":
                    weaponControl = bow;
                    break;
                case "Mace":
                    weaponControl = mace;
                    break;
                case "Red Potion":
                    weaponControl = redPotion;
                    break;
                case "Blue Potion":
                    weaponControl = bluePotion;
                    break;
            }
            weaponControl.Visible = true;

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visible = false;
            }
            else
            {
                weaponControl.Visible = true;
            }
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharecters();
                tabloyenile();
                
            }

            if (game.Level > 7)
            {
                Application.Exit();
            }

            inS.Visible = false;
            inR.Visible = false;
            inB.Visible = false;
            inBlu.Visible = false;
            inMa.Visible = false;

            if (game.CheckPlayerInventory("Sword"))
            {
                inS.Visible = true;
            }
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                inBlu.Visible = true;
            }
            if (game.CheckPlayerInventory("Bow"))
            {
                inB.Visible = true;
            }
            if (game.CheckPlayerInventory("Red Potion"))
            {
                inR.Visible = true;
            }
            if (game.CheckPlayerInventory("Mace"))
            {
                inMa.Visible = true;
            }
           
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            secimyenileme();
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                inS.BorderStyle = BorderStyle.FixedSingle;
                

            }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            secimyenileme();
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                game.Equip("Blue Potion");
                inBlu.BorderStyle = BorderStyle.FixedSingle;
                AUp.Text = "Drink";
                ADown.Visible = false;
                ARight.Visible = false;
                ALeft.Visible = false;


            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            secimyenileme();
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                inB.BorderStyle = BorderStyle.FixedSingle;

            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            secimyenileme();
            if (game.CheckPlayerInventory("Red Potion"))
            {
                game.Equip("Red Potion");
                inR.BorderStyle = BorderStyle.FixedSingle;
                AUp.Text = "Drink";
                ADown.Visible = false;
                ARight.Visible = false;
                ALeft.Visible = false;

            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            secimyenileme();
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                inMa.BorderStyle = BorderStyle.FixedSingle;

            }
        }


        public void secimyenileme()
        {
            inB.BorderStyle = BorderStyle.None;
            inBlu.BorderStyle = BorderStyle.None;
            inS.BorderStyle = BorderStyle.None;
            inR.BorderStyle = BorderStyle.None;
            inMa.BorderStyle = BorderStyle.None;
            AUp.Text = "Up";
            ADown.Visible = true;
            ARight.Visible = true;
            ALeft.Visible = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Up)
            //{
            //    game.Move(Direction.Up, random);
            //    UpdateCharecters();

            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    game.Move(Direction.Down, random);
            //    UpdateCharecters();
            //}
            //if (e.KeyCode == Keys.Right)
            //{
            //    game.Move(Direction.Right, random);
            //    UpdateCharecters();
            //}
            //if (e.KeyCode == Keys.Left)
            //{
            //    game.Move(Direction.Left, random);
            //    UpdateCharecters();
            //}
            //    /////////////////
            //    if (e.KeyCode == Keys.W)
            //    {
            //        game.Attack(Direction.Up, random);
            //        UpdateCharecters();

            //    }
            //    if (e.KeyCode == Keys.S)
            //    {
            //        game.Attack(Direction.Down, random);
            //        UpdateCharecters();
            //    }
            //    if (e.KeyCode == Keys.D)
            //    {
            //        game.Attack(Direction.Right, random);
            //        UpdateCharecters();
            //    }
            //    if (e.KeyCode == Keys.A)
            //    {
            //        game.Attack(Direction.Left, random);
            //        UpdateCharecters();
            //    }



        }

        private void pictureBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void bat_Click(object sender, EventArgs e)
        {

        }

        private void ghost_Click(object sender, EventArgs e)
        {

        }

        private void bow_Click(object sender, EventArgs e)
        {

        }

        private void mace_Click(object sender, EventArgs e)
        {

        }

        private void bluePotion_Click(object sender, EventArgs e)
        {

        }

        private void ghoul_Click(object sender, EventArgs e)
        {

        }

        private void redPotion_Click(object sender, EventArgs e)
        {

        }

        private void sword_Click(object sender, EventArgs e)
        {

        }

        private void MUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharecters();
        }

        private void MLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharecters();
        }

        private void MRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharecters();
        }

        private void MDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharecters();
        }

        private void AUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharecters();
            //if (AUp.Text == "Drink")
            //{
            //    if (inBlu.BorderStyle == BorderStyle.FixedSingle)
            //    {
            //        game.IncreasePlayerHealth(5, random);
            //        secimyenileme();
            //    }

            //    if(inR.BorderStyle==BorderStyle.FixedSingle)
            //    {
            //        game.IncreasePlayerHealth(10, random);
            //        secimyenileme();
            //    }
            //    plyrhitlbl.Text = game.PlayerHitPoints.ToString();

            //}
            secimyenileme();
        }

        private void ALeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharecters();
        }

        private void ARight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharecters();
        }

        private void ADown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharecters();
        }
    }
}
