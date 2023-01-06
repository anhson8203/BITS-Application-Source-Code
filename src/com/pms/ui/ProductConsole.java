package com.pms.ui;

import com.pms.controller.ProductManager;
import com.pms.entity.Customer;
import com.pms.entity.Product;
import com.pms.io.ProductIO;

import java.util.*;

public class ProductConsole {
    private ProductManager pm;
    private ProductIO io;
    private Scanner sc;
    private static ArrayList<Customer> customerList = new ArrayList<>();
    private static ArrayList<Product> productList = new ArrayList<>();

    public ProductConsole() {
        this.sc = new Scanner(System.in);
        this.io = new ProductIO();
        this.pm = new ProductManager(io.load());
    }

    public void login() {
        String username, password;
        System.out.print("Enter username: ");
        username = sc.nextLine();
        System.out.print("Enter password: ");
        password = sc.nextLine();

        if (username.equals("admin") && password.equals("admin")) {
            start();
        } else {
            System.out.println("-----------------------------");
            System.out.println("Nice try. Please enter your credentials again");
            login();
        }
    }

    private int menu() {
        System.out.println("----------MAIN MENU-----------");
        System.out.println("1. Add product");
        System.out.println("2. Show all products");
        System.out.println("3. Remove product");
        System.out.println("4. Create order");
        System.out.println("0. Exit");
        System.out.println("------------------------------");
        System.out.print("Enter a number: ");
        return readInt(4);
    }

    private void start() {
        while (true) {
            int choice = menu();
            switch (choice) {
                case 0 -> System.exit(0);
                case 1 -> addProduct();
                case 2 -> showProducts();
                case 3 -> removeProduct();
                case 4 -> order();
            }
        }
    }

    private int readInt(int max) {
        int choice;
        while (true) {
            try {
                choice = Integer.parseInt(sc.nextLine());
                if ((choice >= 0 && choice <= max))
                    break;
            } catch (Exception e) {
                System.out.print("Input must be a number: ");
            }
        }
        return choice;
    }

    private float readFloat() {
        float price;
        while (true) {
            try {
                price = Float.parseFloat(sc.nextLine());
                if (price >= 0 && price <= Float.MAX_VALUE)
                    break;
            } catch (Exception e) {
                System.out.print("Invalid value. Please enter a float value: $");
            }
        }
        return price;
    }

    private void addProduct() {
        sc = new Scanner(System.in);
        System.out.println("------------------------------");
        System.out.print("Enter product ID: ");
        int id = readInt(Integer.MAX_VALUE);
        System.out.print("Enter product name: ");
        String name = sc.nextLine();
        System.out.print("Enter category: ");
        String category = sc.nextLine();
        System.out.print("Enter price: $");
        float price = readFloat();
        Product p = new Product(id, name, category, price);
        this.pm.addProduct(p);
        this.io.save(pm.getProductList());
        System.out.println("------------------------------");
        System.out.println("Product Added");

        System.out.println("------------------------------");
        while (true) {
            System.out.print("Do you want to add another product? (Y/N) ");
            String option = sc.nextLine().toLowerCase();

            switch (option) {
                case "yes", "y" -> addProduct();
                case "no", "n" -> start();
                default -> {
                    System.out.println("------------------------------");
                    System.out.println("Wrong argument");
                }
            }
        }
    }

    private void showProducts() {
        if (this.pm.count() == 0) {
            System.out.println("------------------------------");
            System.out.println("No Product Yet");
        } else {
            System.out.println("---------ALL PRODUCTS---------");
            for (int i = 0; i < this.pm.count(); i++) {
                Product p = this.pm.getProduct(i);

                if (p.getProductId() < 10) {
                    System.out.println("ID: 0" + p.getProductId());
                } else {
                    System.out.println("ID: " + p.getProductId());
                }

                System.out.println("Product name: " + p.getProductName());
                System.out.println("Category: " + p.getProductCategory());
                System.out.println("Price: $" + p.getPrice() + "\n");
            }
        }
    }

    private void removeProduct() {
        System.out.println("------------------------------");
        if (this.pm.count() == 0) {
            System.out.println("No Product Yet");
        } else {
            System.out.print("Enter a product's ID: ");
            int id = readInt(Integer.MAX_VALUE);
            boolean result = this.pm.removeProduct(id);
            System.out.println("------------------------------");
            if (result) {
                System.out.println("Product removed");
                while (this.pm.count() != 0) {
                    System.out.print("Do you want to remove another product? (Y/N) ");
                    String option = sc.nextLine().toLowerCase();

                    switch (option) {
                        case "yes", "y" -> removeProduct();
                        case "no", "n" -> start();
                        default -> {
                            System.out.println("------------------------------");
                            System.out.println("Wrong argument");
                        }
                    }
                }
            } else {
                System.out.println("Product not found");
            }
        }
    }

    public void order() {
        String option;
        Customer customer = new Customer();

        if (this.pm.count() == 0) {
            System.out.println("------------------------------");
            System.out.println("No Product to be sold");
            start();
        }

        System.out.println("------------------------------");
        System.out.print("Enter Customer Name: ");
        customer.setCustomerName(sc.nextLine());
        System.out.print("Enter Product ID: ");
        customer.setProductId(readInt(Integer.MAX_VALUE));
        System.out.print("Enter Purchase Quantity: ");
        customer.setPurchaseQty(readInt(Integer.MAX_VALUE));
        System.out.println("------------------------------");
        customer.addCustomer(customer);
        customerList.add(customer);

        while (true) {
            System.out.print("Do you have more items? (Y/N) ");
            option = sc.nextLine().toLowerCase();
            switch (option) {
                case "yes", "y" -> order();
                case "no", "n" -> {
                    customer.createOrder(customerList, productList, customer.getCustomerName());
                    start();
                }
                default -> {
                    System.out.println("------------------------------");
                    System.out.println("Wrong argument");
                }
            }
        }
    }
}