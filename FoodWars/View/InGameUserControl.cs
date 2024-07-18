using FoodWars.Properties;
using FoodWars.Utilities;
using FoodWars.Values;
using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class InGameUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        private int[] incorrectMsgBubbleDuration;
        #endregion

        #region Constructors
        public InGameUserControl(BaseForm baseForm)
        {
            InitializeComponent();
            this.BaseForm = baseForm;
            this.incorrectMsgBubbleDuration = new int[3];
        }
        #endregion

        #region Properties
        private BaseForm BaseForm
        {
            get => baseForm;
            set
            {
                if (value == null) throw new Exception("No base form specified!");
                else this.baseForm = value;
            }
        }
        #endregion

        #region Event Handlers
        private void InGameUserControl_Load(object sender, EventArgs e)
        {
            msg_bubble1.Hide();
            msg_bubble2.Hide();
            msg_bubble3.Hide();
            BaseForm.Game.StartGame();
            label_timeLeft.Text = BaseForm.Game.OpenDuration.DurationToString();
            HideIngredients();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Mengupdate waktu bermain dan sisa customer pada user control 
            BaseForm.Game.OpenDuration.Add(-1);
            label_timeLeft.Text = BaseForm.Game.OpenDuration.DurationToString();

            // Simpan jika ada perubahan pelanggan atau msg bubble
            Customers[] previousChairsCondition = new Customers[3];
            for (int i = 0; i < 3; i++) previousChairsCondition[i] = BaseForm.Game.Chairs[i];
            int[] previousIncorrectMsgBubbleDuration = new int[3];
            for (int i = 0; i < 3; i++) previousIncorrectMsgBubbleDuration[i] = incorrectMsgBubbleDuration[i];

            // Memanggil fungsi untuk mengupdate waktu tunggu seluruh customer, mengeluarkan customer yang durasinya habis,
            // serta memberi jeda antar datangnya customer sesuai aturan yang ada. 
            for (int i = 0; i < BaseForm.Game.Chairs.Length; i++) BaseForm.Game.UpdateAllCustomer(i);

            // Mengupdate durasi berubahnya message bubble
            if (incorrectMsgBubbleDuration[0] > 0) incorrectMsgBubbleDuration[0]--;
            if (incorrectMsgBubbleDuration[1] > 0) incorrectMsgBubbleDuration[1]--;
            if (incorrectMsgBubbleDuration[2] > 0) incorrectMsgBubbleDuration[2]--;

            // Mengupdate customer yang muncul 
            for (int i = 0; i < 3; i++)
            {
                if (
                    (previousChairsCondition[i] == null) != (BaseForm.Game.Chairs[i] == null) ||
                    (previousIncorrectMsgBubbleDuration[i] != 0) != (incorrectMsgBubbleDuration[i] != 0)
                    )
                {
                    UpdateWaitingRoom();
                    break;
                }
            }

            // Mengupdate durasi dari tiap customer
            UpdateCustomerDurationLabel();

            if (BaseForm.Game.FinishGame())
            {
                if (BaseForm.Game.AllCustomerServed())
                {
                    // MENANG
                    // Bunyikan SFX
                    timer.Stop();
                    GameWinUserControl gameWinUc = new GameWinUserControl(BaseForm);
                    BaseForm.mainPanel.Controls.Add(gameWinUc);
                    BaseForm.mainPanel.Controls.Remove(this);
                    gameWinUc.Dock = DockStyle.Fill;
                }
                else
                {
                    // KALAH
                    // Bunyikan SFX
                    timer.Stop();
                    GameLoseUserControl gameLoseUc = new GameLoseUserControl(BaseForm);
                    BaseForm.mainPanel.Controls.Add(gameLoseUc);
                    BaseForm.mainPanel.Controls.Remove(this);
                    gameLoseUc.Dock = DockStyle.Fill;
                }

            }
        }

        private void HideIngredients()
        {
            IngredientsMap availableIng = BaseForm.Game.AvailableIngredients;
            // Hide Food Ingredients
            int allowedRice = availableIng.GetAvailableIngredientOfCategory(IngredientCategory.RICE);
            int allowedProtein = availableIng.GetAvailableIngredientOfCategory(IngredientCategory.PROTEIN);
            int allowedVeggies = availableIng.GetAvailableIngredientOfCategory(IngredientCategory.VEGETABLES);
            int allowedSideDish = availableIng.GetAvailableIngredientOfCategory(IngredientCategory.SIDE_DISHES);
            if (allowedRice < 2) pictBox_rice2.Hide();
            if (allowedRice < 3) pictBox_rice3.Hide();
            if (allowedProtein < 2) pictBox_protein2.Hide();
            if (allowedProtein < 3) pictBox_protein3.Hide();
            if (allowedVeggies < 2) pictBox_veggies2.Hide();
            if (allowedVeggies < 3) pictBox_veggies3.Hide();
            if (allowedSideDish < 2) pictBox_sideDish2.Hide();
            if (allowedSideDish < 3) pictBox_sideDish3.Hide();

            // Hide Beverages
            if (BaseForm.Game.Player.Level / 50 + 1 < 2) pictBox_ocha_main.Hide();
            if (BaseForm.Game.Player.Level / 50 + 1 < 3) pictBox_sake_main.Hide();
        }

        private void UpdateWaitingRoom()
        {
            // Mengupdate income
            label_income.Text = BaseForm.Game.DailyRevenue.ToString();

            Customers[] customerWaiting = BaseForm.Game.Chairs;
            // Mengupdate tampilan ruang tunggu berdasarkan array of customers
            for (int i = 0; i < customerWaiting.Length; i++)
            {
                if (customerWaiting[i] != null)
                {
                    if (i == 0)
                    {
                        itemBase_1A.BackgroundImage = null;
                        rice_1A.BackgroundImage = null;
                        protein_1A.BackgroundImage = null;
                        veggie_1A.BackgroundImage = null;
                        sideDish_1A.BackgroundImage = null;
                        itemBase_1B.BackgroundImage = null;
                        rice_1B.BackgroundImage = null;
                        protein_1B.BackgroundImage = null;
                        veggie_1B.BackgroundImage = null;
                        sideDish_1B.BackgroundImage = null;
                        itemBase_1C.BackgroundImage = null;
                        rice_1C.BackgroundImage = null;
                        protein_1C.BackgroundImage = null;
                        veggie_1C.BackgroundImage = null;
                        sideDish_1C.BackgroundImage = null;
                        if (incorrectMsgBubbleDuration[i] == 0) msg_bubble1.BackgroundImage = Resources.msg_bubble;
                        else msg_bubble1.BackgroundImage = Resources.msg_bubble_incorrect;
                        msg_bubble1.Show();
                        // timerLabel_c1.Text = customerWaiting[i].WaitingDuration.GetSecond().ToString();
                        pictBox_cust1.BackgroundImage = customerWaiting[i].Picture;
                        pictBox_cust1.Show();
                        if (customerWaiting[i].Orders.Count >= 1)
                        {
                            if (customerWaiting[i].Orders[0] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[0];
                                itemBase_1A.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_1A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_1A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_1A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_1A.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_1A.BackgroundImage = customerWaiting[i].Orders[0].Picture;
                            }
                        }
                        if (customerWaiting[i].Orders.Count >= 2)
                        {
                            if (customerWaiting[i].Orders[1] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[1];
                                itemBase_1B.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_1B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_1B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_1B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_1B.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_1B.BackgroundImage = customerWaiting[i].Orders[1].Picture;
                            }
                        }
                        if (customerWaiting[i].Orders.Count == 3)
                        {
                            if (customerWaiting[i].Orders[2] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[2];
                                itemBase_1C.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_1C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_1C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_1C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_1C.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_1C.BackgroundImage = customerWaiting[i].Orders[2].Picture;
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        itemBase_2A.BackgroundImage = null;
                        rice_2A.BackgroundImage = null;
                        protein_2A.BackgroundImage = null;
                        veggie_2A.BackgroundImage = null;
                        sideDish_2A.BackgroundImage = null;
                        itemBase_2B.BackgroundImage = null;
                        rice_2B.BackgroundImage = null;
                        protein_2B.BackgroundImage = null;
                        veggie_2B.BackgroundImage = null;
                        sideDish_2B.BackgroundImage = null;
                        itemBase_2C.BackgroundImage = null;
                        rice_2C.BackgroundImage = null;
                        protein_2C.BackgroundImage = null;
                        veggie_2C.BackgroundImage = null;
                        sideDish_2C.BackgroundImage = null;
                        if (incorrectMsgBubbleDuration[i] == 0) msg_bubble2.BackgroundImage = Resources.msg_bubble;
                        else msg_bubble2.BackgroundImage = Resources.msg_bubble_incorrect;
                        msg_bubble2.Show();
                        // timerLabel_c2.Text = customerWaiting[i].WaitingDuration.GetSecond().ToString();
                        pictBox_cust2.BackgroundImage = customerWaiting[i].Picture;
                        pictBox_cust2.Show();
                        if (customerWaiting[i].Orders.Count >= 1)
                        {
                            if (customerWaiting[i].Orders[0] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[0];
                                itemBase_2A.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_2A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_2A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_2A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_2A.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_2A.BackgroundImage = customerWaiting[i].Orders[0].Picture;
                            }
                        }
                        if (customerWaiting[i].Orders.Count >= 2)
                        {
                            if (customerWaiting[i].Orders[1] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[1];
                                itemBase_2B.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_2B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_2B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_2B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_2B.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_2B.BackgroundImage = customerWaiting[i].Orders[1].Picture;
                            }
                        }
                        if (customerWaiting[i].Orders.Count == 3)
                        {
                            itemBase_2C.Show();
                            if (customerWaiting[i].Orders[2] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[2];
                                itemBase_2C.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_2C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_2C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_2C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_2C.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_2C.BackgroundImage = customerWaiting[i].Orders[2].Picture;
                            }
                        }
                    }
                    else
                    {
                        itemBase_3B.BackgroundImage = null;
                        rice_3B.BackgroundImage = null;
                        protein_3B.BackgroundImage = null;
                        veggie_3B.BackgroundImage = null;
                        sideDish_3B.BackgroundImage = null;
                        itemBase_3A.BackgroundImage = null;
                        rice_3A.BackgroundImage = null;
                        protein_3A.BackgroundImage = null;
                        veggie_3A.BackgroundImage = null;
                        sideDish_3A.BackgroundImage = null;
                        itemBase_3C.BackgroundImage = null;
                        rice_3C.BackgroundImage = null;
                        protein_3C.BackgroundImage = null;
                        veggie_3C.BackgroundImage = null;
                        sideDish_3C.BackgroundImage = null;
                        if (incorrectMsgBubbleDuration[i] == 0) msg_bubble3.BackgroundImage = Resources.msg_bubble;
                        else msg_bubble3.BackgroundImage = Resources.msg_bubble_incorrect;
                        msg_bubble3.Show();
                        // timerLabel_c3.Text = customerWaiting[i].WaitingDuration.GetSecond().ToString();
                        pictBox_cust3.BackgroundImage = customerWaiting[i].Picture;
                        pictBox_cust3.Show();
                        if (customerWaiting[i].Orders.Count >= 1)
                        {
                            if (customerWaiting[i].Orders[0] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[0];
                                itemBase_3A.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_3A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_3A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_3A.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_3A.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_3A.BackgroundImage = customerWaiting[i].Orders[0].Picture;
                            }
                        }
                        if (customerWaiting[i].Orders.Count >= 2)
                        {
                            if (customerWaiting[i].Orders[1] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[1];
                                itemBase_3B.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_3B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_3B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_3B.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_3B.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_3B.BackgroundImage = customerWaiting[i].Orders[1].Picture;
                            }
                        }
                        if (customerWaiting[i].Orders.Count == 3)
                        {
                            if (customerWaiting[i].Orders[2] is Foods)
                            {
                                Foods foodToDisplay = (Foods)customerWaiting[i].Orders[2];
                                itemBase_3C.BackgroundImage = foodToDisplay.Picture;
                                foreach (Ingredients ing in foodToDisplay.Ingredients)
                                {
                                    if (ing.Category == IngredientCategory.RICE)
                                    {
                                        rice_3C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.PROTEIN)
                                    {
                                        sideDish_3C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.VEGETABLES)
                                    {
                                        protein_3C.BackgroundImage = ing.Picture;
                                    }
                                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                                    {
                                        veggie_3C.BackgroundImage = ing.Picture;
                                    }
                                }
                            }
                            else
                            {
                                itemBase_3C.BackgroundImage = customerWaiting[i].Orders[2].Picture;
                            }
                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        msg_bubble1.Hide();
                        pictBox_cust1.Hide();
                        itemBase_1A.BackgroundImage = null;
                        rice_1A.BackgroundImage = null;
                        protein_1A.BackgroundImage = null;
                        veggie_1A.BackgroundImage = null;
                        sideDish_1A.BackgroundImage = null;
                        itemBase_1B.BackgroundImage = null;
                        rice_1B.BackgroundImage = null;
                        protein_1B.BackgroundImage = null;
                        veggie_1B.BackgroundImage = null;
                        sideDish_1B.BackgroundImage = null;
                        itemBase_1C.BackgroundImage = null;
                        rice_1C.BackgroundImage = null;
                        protein_1C.BackgroundImage = null;
                        veggie_1C.BackgroundImage = null;
                        sideDish_1C.BackgroundImage = null;
                    }
                    else if (i == 1)
                    {
                        msg_bubble2.Hide();
                        pictBox_cust2.Hide();
                        itemBase_2A.BackgroundImage = null;
                        rice_2A.BackgroundImage = null;
                        protein_2A.BackgroundImage = null;
                        veggie_2A.BackgroundImage = null;
                        sideDish_2A.BackgroundImage = null;
                        itemBase_2B.BackgroundImage = null;
                        rice_2B.BackgroundImage = null;
                        protein_2B.BackgroundImage = null;
                        veggie_2B.BackgroundImage = null;
                        sideDish_2B.BackgroundImage = null;
                        itemBase_2C.BackgroundImage = null;
                        rice_2C.BackgroundImage = null;
                        protein_2C.BackgroundImage = null;
                        veggie_2C.BackgroundImage = null;
                        sideDish_2C.BackgroundImage = null;
                    }
                    else
                    {
                        msg_bubble3.Hide();
                        pictBox_cust3.Hide();
                        itemBase_3B.BackgroundImage = null;
                        rice_3B.BackgroundImage = null;
                        protein_3B.BackgroundImage = null;
                        veggie_3B.BackgroundImage = null;
                        sideDish_3B.BackgroundImage = null;
                        itemBase_3A.BackgroundImage = null;
                        rice_3A.BackgroundImage = null;
                        protein_3A.BackgroundImage = null;
                        veggie_3A.BackgroundImage = null;
                        sideDish_3A.BackgroundImage = null;
                        itemBase_3C.BackgroundImage = null;
                        rice_3C.BackgroundImage = null;
                        protein_3C.BackgroundImage = null;
                        veggie_3C.BackgroundImage = null;
                        sideDish_3C.BackgroundImage = null;
                    }
                }
            }
        }

        private void UpdateSelectedItemLabel()
        {
            // Mengupdate label selected item berdasarkan item yang dipilih player
            if (BaseForm.Game.SelectedItem is Foods) label_selectedItem.Text = "Food";
            else if (BaseForm.Game.SelectedItem is Beverages) label_selectedItem.Text = "Beverage";
            else if (BaseForm.Game.SelectedItem is Merchandise) label_selectedItem.Text = "Merchandise";
            else label_selectedItem.Text = "-";
        }

        private void UpdateCustomerDurationLabel()
        {
            Customers[] customerWaiting = BaseForm.Game.Chairs;
            if (customerWaiting[0] != null) timerLabel_c1.Text = customerWaiting[0].WaitingDuration.GetSecond().ToString();
            if (customerWaiting[1] != null) timerLabel_c2.Text = customerWaiting[1].WaitingDuration.GetSecond().ToString();
            if (customerWaiting[2] != null) timerLabel_c3.Text = customerWaiting[2].WaitingDuration.GetSecond().ToString();
        }

        private void UpdatePrepTable()
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                Foods foodToDisplay = BaseForm.Game.FoodsBeingPrepared;
                itemBase_main.BackgroundImage = foodToDisplay.Picture;
                foreach (Ingredients ing in foodToDisplay.Ingredients)
                {
                    if (ing.Category == IngredientCategory.RICE)
                    {
                        rice_main.BackgroundImage = ing.Picture;
                    }
                    else if (ing.Category == IngredientCategory.PROTEIN)
                    {
                        sideDish_main.BackgroundImage = ing.Picture;
                    }
                    else if (ing.Category == IngredientCategory.VEGETABLES)
                    {
                        protein_main.BackgroundImage = ing.Picture;
                    }
                    else if (ing.Category == IngredientCategory.SIDE_DISHES)
                    {
                        veggies_main.BackgroundImage = ing.Picture;
                    }
                }
            }
            else
            {
                itemBase_main.BackgroundImage = null;
                rice_main.BackgroundImage = null;
                protein_main.BackgroundImage = null;
                veggies_main.BackgroundImage = null;
                sideDish_main.BackgroundImage = null;
            }

            if (BaseForm.Game.BeveragesBeingPrepared != null)
            {
                bev_main.BackgroundImage = BaseForm.Game.BeveragesBeingPrepared.Picture;
            }
            else
            {
                bev_main.BackgroundImage = null;
            }
        }

       
        private void PictBox_cust1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Chairs[0] != null && BaseForm.Game.SelectedItem != null)
            {
                if (BaseForm.Game.CheckOrder(0))
                {
                    // Pesanan yang diberikan BENAR

                    if (BaseForm.Game.SelectedItem is Foods) BaseForm.Game.FoodsBeingPrepared = null;
                    else if (BaseForm.Game.SelectedItem is Beverages) BaseForm.Game.BeveragesBeingPrepared = null;
                    UpdateWaitingRoom();
                    UpdatePrepTable();

                    // Bunyikan SFX 
                }
                else
                {
                    // Pesanan yang diberikan SALAH

                    incorrectMsgBubbleDuration[0] = 1;
                    UpdateWaitingRoom();

                    // Bunyikan SFX 
                }
                BaseForm.Game.SelectedItem = null; // Mengosongkan item setelah dipilih
                UpdateSelectedItemLabel();
            }
        }

        private void PictBox_cust2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Chairs[1] != null && BaseForm.Game.SelectedItem != null)
            {
                if (BaseForm.Game.CheckOrder(1))
                {
                    Console.WriteLine(BaseForm.Game.SelectedItem);
                    if (BaseForm.Game.SelectedItem is Foods)
                    {
                        BaseForm.Game.FoodsBeingPrepared = null;
                        Console.WriteLine("CALLED!");
                    }
                    else if (BaseForm.Game.SelectedItem is Beverages) BaseForm.Game.BeveragesBeingPrepared = null;
                    UpdateWaitingRoom();
                    UpdatePrepTable();
                }
                else
                {
                    incorrectMsgBubbleDuration[1] = 1;
                    UpdateWaitingRoom();
                }
                BaseForm.Game.SelectedItem = null;
                UpdateSelectedItemLabel();
            }
        }

        private void PictBox_cust3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Chairs[2] != null && BaseForm.Game.SelectedItem != null)
            {
                if (BaseForm.Game.CheckOrder(2))
                {
                    if (BaseForm.Game.SelectedItem is Foods) BaseForm.Game.FoodsBeingPrepared = null;
                    else if (BaseForm.Game.SelectedItem is Beverages) BaseForm.Game.BeveragesBeingPrepared = null;
                    UpdateWaitingRoom();
                    UpdatePrepTable();
                }
                else
                {
                    incorrectMsgBubbleDuration[2] = 1;
                    UpdateWaitingRoom();
                }
                BaseForm.Game.SelectedItem = null;
                UpdateSelectedItemLabel();
            }
        }

        private void Button_Pause_MouseEnter(object sender, EventArgs e)
        {
            pictBox_buttonPause.BackgroundImage = Resources.button_pause_stroke;
        }

        private void Button_Pause_MouseLeave(object sender, EventArgs e)
        {
            pictBox_buttonPause.BackgroundImage = Resources.button_pause;
        }

        private void Button_Pause_Click(object sender, EventArgs e)
        {
            PauseUserControl pauseUc = new PauseUserControl(BaseForm, this);
            this.timer.Stop();

            BaseForm.mainPanel.Controls.Add(pauseUc);
            BaseForm.mainPanel.Controls.Remove(this);
            pauseUc.Dock = DockStyle.Fill;
        }

        private void pictBox_plate_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared == null)
            {
                BaseForm.Game.CreateNewFood();
                UpdatePrepTable();
            }
        }

        private void pictBox_rice3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.RICE, 2)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_rice2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.RICE, 1)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_rice1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.RICE, 0)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_protein3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.PROTEIN, 2)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_protein2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.PROTEIN, 1)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_protein1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.PROTEIN, 0)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_veggies3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.VEGETABLES, 2)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_veggies2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.VEGETABLES, 1)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_veggies1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.VEGETABLES, 0)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_sideDish3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.SIDE_DISHES, 2)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_sideDish2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.SIDE_DISHES, 1)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_sideDish1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.FoodsBeingPrepared != null)
            {
                BaseForm.Game.FoodsBeingPrepared.SwitchIngredient(
                    BaseForm.Game.AvailableIngredients.GetIngredientsOfCategory(IngredientCategory.SIDE_DISHES, 0)
                );
                UpdatePrepTable();
            }
        }

        private void pictBox_ocha_main_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared != null)
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(BeverageType.OCHA);
            }
            UpdatePrepTable();
        }

        private void pictBox_sake_main_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared != null)
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(BeverageType.SAKE);
            }
            UpdatePrepTable();
        }

        private void pictBox_water_main_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared != null)
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(BeverageType.WATER);
            }
            UpdatePrepTable();
        }

        private void pictBox_ice_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared != null)
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(!BaseForm.Game.BeveragesBeingPrepared.IsCold);
            }
            UpdatePrepTable();
        }

        private void pictBox_glass_S_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared == null)
            {
                BaseForm.Game.CreateNewBeverage(GlassSize.SMALL);
                UpdatePrepTable();
            } 
            else
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(GlassSize.SMALL);
                UpdatePrepTable();
            }
        }

        private void pictBox_glass_M_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared == null)
            {
                BaseForm.Game.CreateNewBeverage(GlassSize.MEDIUM);
                UpdatePrepTable();
            }
            else
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(GlassSize.MEDIUM);
                UpdatePrepTable();
            }
        }

        private void pictBox_glass_L_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.BeveragesBeingPrepared == null)
            {
                BaseForm.Game.CreateNewBeverage(GlassSize.LARGE);
                UpdatePrepTable();
            }
            else
            {
                BaseForm.Game.BeveragesBeingPrepared.SwitchVariety(GlassSize.LARGE);
                UpdatePrepTable();
            }
        }

        private void food_main_Click(object sender, EventArgs e)
        {
            Foods selectedFood = BaseForm.Game.FoodsBeingPrepared;
            if (selectedFood != null)
            {
                if (selectedFood.Ingredients.Count == 4)
                {
                    BaseForm.Game.SelectedItem = selectedFood;
                    label_selectedItem.Text = "Food";
                    UpdateWaitingRoom();
                }
            }
        }

        private void bev_main_Click(object sender, EventArgs e)
        {
            Beverages selectedBeverage = BaseForm.Game.BeveragesBeingPrepared;
            if (selectedBeverage != null)
            {
                if (selectedBeverage.BeverageType != BeverageType.UNASSIGNED)
                {
                    BaseForm.Game.SelectedItem = selectedBeverage;
                    label_selectedItem.Text = "Beverage";
                    UpdateWaitingRoom();
                }
            }
        }

        private void pictBox_merch1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.SelectMerch(0)) label_selectedItem.Text = "Merchandise";
            UpdateWaitingRoom();
        }

        private void pictBox_merch2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.SelectMerch(1)) label_selectedItem.Text = "Merchandise";
            UpdateWaitingRoom();
        }

        private void pictBox_merch3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.SelectMerch(2)) label_selectedItem.Text = "Merchandise";
            UpdateWaitingRoom();
        }

        #endregion
        private void sideDish_main_Paint(object sender, PaintEventArgs e)
        {
            // JANGAN DIISI
        }
    }
}
