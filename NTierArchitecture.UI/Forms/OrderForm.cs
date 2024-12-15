using NTierArchitecture.Business.Services;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTierArchitecture.UI.Forms
{
    public partial class OrderForm : Form
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        public OrderForm()
        {
            InitializeComponent();
            _dbContext = new ApplicationDBContext();
            ProductRepository productRepository = new ProductRepository(_dbContext);
            OrderRepository orderRepository = new OrderRepository(_dbContext);
            OrderDetailRepository orderDetailRepository = new OrderDetailRepository(_dbContext);

            _productService = new ProductService(productRepository);
            _orderService = new OrderService(orderRepository);
            _orderDetailService = new OrderDetailService(orderDetailRepository);

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            GetAllProductsBySearchText(string.Empty);
        }

        private void GetAllProductsBySearchText(string searhText)
        {
            if (!string.IsNullOrEmpty(searhText.ToLower()) && searhText.Length >= 3)
            {
                //Ürünleri filtreye göre getir:
                var productList = _productService.GetAll().Where(p => p.ProductName.ToLower().Contains(searhText.ToLower()));

                lstProductList.ValueMember = "Id";
                lstProductList.DisplayMember = "ProductName";
                lstProductList.DataSource = productList.ToList();
            }

            if (searhText.Length == 0)
            {
                lstProductList.ValueMember = "Id";
                lstProductList.DisplayMember = "ProductName";
                lstProductList.DataSource = _productService.GetAll().ToList();
            }
        }

        private void btnAddBasket_Click(object sender, EventArgs e)
        {

        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetAllProductsBySearchText(txtSearch.Text);
        }
    }
}
