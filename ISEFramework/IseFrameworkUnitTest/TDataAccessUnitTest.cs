using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;



namespace IseFrameworkUnitTest
{
    [TestClass]
    public class TDataAccessUnitTest
    {
        [TestMethod]
        public void DataAcccessGetAllTestMethod()
        {
            //CustomerTDataAccess cda = new CustomerTDataAccess();
            //var list =  cda.GetAll();
            //Assert.IsNotNull(list);
        }
        //[TestMethod]
        //public void DataAcccessGetAllPredicateTestMethod()
        //{
        //    string name = "nima";
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    List<CustomerDto> lst = new List<CustomerDto>(cda.GetAll(it => it.FNAME == name));
        //    Assert.IsNotNull(lst);

        //    bool result = lst.Exists(it => it.FNAME == name);
        //    Assert.AreEqual(result, true);
        //}
        //[TestMethod]
        //public void DataAcccessGetOrdersTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    List<OrderDto> lst = new List<OrderDto>(cda.GetOrders(44));
        //    Assert.IsNotNull(lst);
        //    int count =  lst.Count;            
        //    Assert.AreEqual(count, 8);
        //}
        //[TestMethod]
        //public void DataAcccessGetSingleTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    var customer = cda.GetSingle(it => it.CUSTOMER_ID == 44);
        //    Assert.IsNotNull(customer);
        //    Assert.AreEqual(customer.FNAME, "jafar");
        //}
        //[TestMethod]
        //public void DataAcccessCountTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    long customerCount = cda.Count();
        //    Assert.AreEqual(customerCount, 4036);
        //}
        //[TestMethod]
        //public void DataAcccessCountWithParamTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    long customerCount = cda.Count(it => it.FNAME == "jafar");
        //    Assert.AreEqual(customerCount, 1);
        //}
        //[TestMethod]
        //public void DataAcccessDeleteTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
            
        //    CustomerDto dto = new CustomerDto(){
        //     CUSTOMER_ID = 592
        //    };
        //    long count = cda.Count(it => it.CUSTOMER_ID == dto.CUSTOMER_ID);
        //    Assert.AreEqual(count, 1);
        //    cda.Delete(dto);
        //    count = cda.Count(it => it.CUSTOMER_ID == dto.CUSTOMER_ID);
        //    Assert.AreEqual(count, 0);            
        //}
        //[TestMethod]
        //public void DataAcccessDeleteListTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();

        //    CustomerDto dto1 = new CustomerDto()
        //    {
        //        CUSTOMER_ID = 593
        //    };
        //    CustomerDto dto2 = new CustomerDto()
        //    {
        //        CUSTOMER_ID = 594
        //    };
        //    List<CustomerDto> list = new List<CustomerDto>();
        //    list.Add(dto1);
        //    list.Add(dto2);
        //    long count = cda.Count(it => it.CUSTOMER_ID == dto1.CUSTOMER_ID || it.CUSTOMER_ID == dto2.CUSTOMER_ID);
        //    Assert.AreEqual(count, 2);
        //    cda.Delete(list);
        //    count = cda.Count(it => it.CUSTOMER_ID == dto1.CUSTOMER_ID || it.CUSTOMER_ID == dto2.CUSTOMER_ID);
        //    Assert.AreEqual(count, 0);
        //}
        //[TestMethod]
        //public void DataAcccessInsertTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();

        //    CustomerDto dto1 = new CustomerDto()
        //    {
        //        FNAME ="mytestF4",
        //        LNAME = "mytestL2",
        //        PHONE="920032"               
        //    };
           
        //    cda.Insert(dto1);
        //    var single = cda.GetSingle(it => it.CUSTOMER_ID == dto1.CUSTOMER_ID);
        //    Assert.IsNotNull(single);
        //    Assert.AreEqual(single.FNAME,dto1.FNAME);
        //}
        //[TestMethod]
        //public void DataAcccessInsertListTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();

        //    CustomerDto dto1 = new CustomerDto()
        //    {
        //        FNAME = "mytestF3",
        //        LNAME = "mytestL3",
        //        PHONE = "920033"
        //    };
        //    CustomerDto dto2 = new CustomerDto()
        //    {
        //        FNAME = "mytestF4",
        //        LNAME = "mytestL4",
        //        PHONE = "920034"
        //    };
        //    List<CustomerDto> list = new List<CustomerDto>();
        //    list.Add(dto1);
        //    list.Add(dto2);
        //    cda.Insert(list);
        //    var result = cda.GetAll(it => it.CUSTOMER_ID == dto1.CUSTOMER_ID || it.CUSTOMER_ID == dto2.CUSTOMER_ID);
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(result.Count, 2);
        //}
        //[TestMethod]
        //public void DataAcccessUpdateTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    var customer=  cda.GetSingle(it => it.CUSTOMER_ID == 44);
        //    customer.FNAME = "hasan";
        //    customer.LNAME = "rezaie";
        //    customer.PHONE = "5546";
        //    cda.Update(customer);
        //    var single = cda.GetSingle(it => it.CUSTOMER_ID == customer.CUSTOMER_ID);
        //    Assert.AreEqual(single.FNAME, customer.FNAME);
        //}
        //[TestMethod]
        //public void DataAcccessUpdateListTestMethod()
        //{
        //    CustomerTDataAccess cda = new CustomerTDataAccess();
        //    var customers = cda.GetAll(it => it.CUSTOMER_ID == 44 || it.CUSTOMER_ID == 45);
        //    Assert.AreEqual(customers.Count, 2);
        //    customers[0].FNAME = "jafar";
        //    customers[1].FNAME = "karam";
        //    cda.Update((List<CustomerDto>)customers);
        //    var customers2 =  cda.GetAll(it => it.CUSTOMER_ID == 44 || it.CUSTOMER_ID == 45);
        //    Assert.AreEqual(customers2.Count, 2);
        //    Assert.AreEqual(customers2[0].FNAME, customers[0].FNAME);
        //    Assert.AreEqual(customers2[1].FNAME, customers[1].FNAME);
        //}
       
    }
}
