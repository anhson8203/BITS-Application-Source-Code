package com.pms.entity;

import java.util.ArrayList;

public class Customer {
    private int customerId, purchaseQty, productId;
    private String customerName;
    private double totalCost;

    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    public int getPurchaseQty() {
        return purchaseQty;
    }

    public void setPurchaseQty(int purchaseQty) {
        this.purchaseQty = purchaseQty;
    }

    public int getProductId() {
        return productId;
    }

    public void setProductId(int productId) {
        this.productId = productId;
    }

    public String getCustomerName() {
        return customerName;
    }

    public void setCustomerName(String customerName) {
        this.customerName = customerName;
    }

    public double getTotalCost() {
        return totalCost;
    }

    public void setTotalCost(double totalCost) {
        this.totalCost = totalCost;
    }

    public void addCustomer(Customer customer) {
        this.customerName = customer.customerName;
        this.productId = customer.productId;
        this.purchaseQty = customer.purchaseQty;
    }

    public void createOrder(ArrayList<Customer> arr, ArrayList<Product> productList, String customerName) {
        float total = 0;
        for (Customer customer : arr) {
            if (customer.customerName.equals(customerName)) {
                System.out.println("-------------------------");
                if (customer.productId < 10) {
                    System.out.println("ID: 0" + customer.productId);
                } else {
                    System.out.println("ID: " + customer.productId);
                }

                System.out.println("Customer Fullname: " + customer.customerName);
                System.out.println("Quantity: " + customer.purchaseQty);
                System.out.println("-------------------------");

                for (Product product : productList) {
                    if (product.getProductId() == customer.customerId) {
                        total += customer.purchaseQty * product.getPrice();
                    }
                }
            }
            System.out.println("Total bill: " + total);
        }
    }
}