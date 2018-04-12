using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace GridViewFewLines
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<int, string> GetDicSource()
        {
            return new Dictionary<int, string>
            {
                { 1, @"Лежа на гумне в омете, долго читал — и вдруг возмутило. Опять с раннего утра читаю, опять с книгой в руках! И так изо дня в день, с самого детства! Полжизни прожил в каком-то несуществующем мире, среди людей, никогда не бывших, выдуманных, волнуясь их судьбами, их радостями и печалями, как своими собственными, до могилы связав себя с Авраамом и Исааком, с пелазгами и этрусками, с Сократом и Юлием Цезарем, Гамлетом и Данте, Гретхен и Чацким, Собакевичем и Офелией, Печориным и Наташей Ростовой! И как теперь разобраться среди действительных и вымышленных спутников моего земного существования? Как разделить их, как определить степени их влияния на меня?"},
                { 2, @"Я читал, жил чужими выдумками, а поле, усадьба, деревня, мужики, лошади, мухи, шмели, птицы, облака — все жило своей собственной, настоящей жизнью. И вот я внезапно почувствовал это и очнулся от книжного наваждения, отбросил книгу в солому и с удивлением и с радостью, какими-то новыми глазами смотрю кругом, остро вижу, слышу, обоняю, — главное, чувствую что-то необыкновенно простое и в то же время необыкновенно сложное, то глубокое, чудесное, невыразимое, что есть в жизни и во мне самом и о чем никогда не пишут как следует в книгах."},
                { 3, @"Пока я читал, в природе сокровенно шли изменения. Было солнечно, празднично; теперь все померкло, стихло. В небе мало-помалу собрались облака и тучки, кое-где, — особенно к югу, — еще светлые, красивые, а к западу, за деревней, за ее лозинами, дождевые, синеватые, скучные. Тепло, мягко пахнет далеким полевым дождем. В саду поет одна иволга."}
            };
        }

        // Настроить колонки
        private void SetupColumns()
        {
            gridView1.PopulateColumns();

            if (gridView1.Columns.Count > 0)
            {
                gridView1.Columns[0].Caption = @"ID";
                gridView1.Columns[0].OptionsColumn.FixedWidth = true;
                gridView1.Columns[0].Width = 75;
                gridView1.Columns[0].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridView1.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }

            if (gridView1.Columns.Count > 1)
            {
                gridView1.Columns[1].Caption = @"TEXT";
                gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridView1.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            }

            // Автовысота строк
            gridView1.OptionsView.RowAutoHeight = true;
        }

        // Настроить многострочный режим для колонки текста
        private void SetupWrapColumns(int col)
        {
            if (gridView1.Columns.Count > col)
            {
                var repositoryItemMemoEdit = new RepositoryItemMemoEdit
                {
                    // Перенос строк
                    WordWrap = true
                };

                gridView1.Columns[col].ColumnEdit = repositoryItemMemoEdit;
            }
        }

        // Добавить строки
        private void buttonAddRows_Click(object sender, EventArgs e)
        {
            // Источник
            gridControl1.DataSource = GetDicSource();

            // Настроить колонки
            SetupColumns();

            // Настроить многострочный режим для колонки текста
            SetupWrapColumns(1);
        }
    }
}
