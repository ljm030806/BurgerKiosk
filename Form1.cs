namespace BurgerKiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 폼 로드(Load) 이벤트 연결
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. 모든 선택 초기화
            btnClear_Click(null, EventArgs.Empty);

            // 2. 포커스를 다른 컨트롤로 옮겨서 라디오 버튼 자동 선택 방지
            this.ActiveControl = btnClear;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rdoHamBurger.Checked = false;
            rdoBulgogiBurger.Checked = false;
            rdoChickenBurger.Checked = false;
            chkPotato.Checked = false;
            chkCola.Checked = false;
            chkCheese.Checked = false;
            chkSauce.Checked = false;
            lstOrder.Items.Clear();
            lblTotalCost.Text = "";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 버거(메인 메뉴)가 하나도 선택되지 않았는지 확인
            if (!rdoHamBurger.Checked && !rdoBulgogiBurger.Checked && !rdoChickenBurger.Checked)
            {
                // 경고 메시지 출력
                lblTotalCost.ForeColor = Color.Red; // 경고 메시지를 빨간색으로 표시
                lblTotalCost.Text = "주문을 해주세요";
                return; // 아래 주문 로직을 실행하지 않고 메서드 종료
            }

            int totalCost = 0;
            lblTotalCost.ForeColor = Color.Blue;
            lstOrder.Items.Clear(); // 새 주문 시 깔끔하게 이전 리스트 초기화 추천
            
            if (rdoHamBurger.Checked) 
            {
                lstOrder.Items.Add("햄버거5,000원");
                totalCost += 5000;
            }
            else if (rdoBulgogiBurger.Checked) 
            {
                totalCost += 4000;
                lstOrder.Items.Add("불고기버거4,000원");
            }
            else if (rdoChickenBurger.Checked)
            {
                totalCost += 3000;
                lstOrder.Items.Add("치킨버거3,000원");
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
            lblTotalCost.Text = $"총금액: {totalCost:N0}원";
        }
    }
}
