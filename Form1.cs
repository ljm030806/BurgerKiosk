namespace BurgerKiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnClear_Click(null, EventArgs.Empty);

            this.ActiveControl = btnClear;
            this.AcceptButton = btnOrder;

            // 모든 메뉴와 옵션의 체크 상태가 변할 때마다 즉시 알림을 받도록 이벤트 연결
            rdoHamBurger.CheckedChanged += UpdateOrderList;
            rdoBulgogiBurger.CheckedChanged += UpdateOrderList;
            rdoChickenBurger.CheckedChanged += UpdateOrderList;
            chkPotato.CheckedChanged += UpdateOrderList;
            chkCola.CheckedChanged += UpdateOrderList;
            chkCheese.CheckedChanged += UpdateOrderList;
            chkSauce.CheckedChanged += UpdateOrderList;
        }

        // ==========================================
        // ★ 지워졌던 btnClear_Click 메서드를 다시 복구합니다.
        // ==========================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            rdoHamBurger.Checked = false;
            rdoBulgogiBurger.Checked = false;
            rdoChickenBurger.Checked = false;
            
            // 탭(Tab) 키 이동을 위해 첫 번째 항목 탭 정지 허용
            rdoHamBurger.TabStop = true;

            chkPotato.Checked = false;
            chkCola.Checked = false;
            chkCheese.Checked = false;
            chkSauce.Checked = false;
            lstOrder.Items.Clear();
            lblTotalCost.Text = "";
        }
        // ==========================================

        private void UpdateOrderList(object sender, EventArgs e)
        {
            int totalCost = 0;
            lblTotalCost.ForeColor = Color.Blue;
            lstOrder.Items.Clear(); // 리스트 초기화 후 새로 그리기

            if (rdoHamBurger.Checked) 
            {
                lstOrder.Items.Add("햄버거5,000원");
                totalCost += 5000;
            }
            if (rdoBulgogiBurger.Checked) 
            {
                lstOrder.Items.Add("불고기버거4,000원");
                totalCost += 4000;
            }
            if (rdoChickenBurger.Checked)
            {
                lstOrder.Items.Add("치킨버거3,000원");
                totalCost += 3000;
            }

            if (chkPotato.Checked) 
            {
                lstOrder.Items.Add("감자튀김3,500원");
                totalCost += 3500;
            }
            if (chkCola.Checked) 
            {
                lstOrder.Items.Add("콜라2,500원");
                totalCost += 2500;
            }
            if (chkCheese.Checked)
            {
                lstOrder.Items.Add("치즈추가1,500원");
                totalCost += 1500;
            }
            if (chkSauce.Checked)
            {
                lstOrder.Items.Add("소스추가500원");
                totalCost += 500;
            }

            // 아무것도 선택 안된 상태면 0원으로 표시
            if (totalCost == 0)
                lblTotalCost.Text = "총금액: 0원";
            else
                lblTotalCost.Text = $"총금액: {totalCost:N0}원";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 아무 버거도 선택하지 않았을 때의 경고 안내만 남겨둡니다.
            if (!rdoHamBurger.Checked && !rdoBulgogiBurger.Checked && !rdoChickenBurger.Checked)
            {
                lblTotalCost.ForeColor = Color.Red;
                lblTotalCost.Text = "주문을 해주세요";
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (this.ActiveControl == chkPotato ||
                    this.ActiveControl == chkCola ||
                    this.ActiveControl == chkCheese ||
                    this.ActiveControl == chkSauce)
                {
                    btnOrder.Focus(); 
                    return true;      
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
