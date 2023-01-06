package com.pms.controller;

import com.pms.entity.Product;

import java.io.File;
import java.util.*;

public class ProductManager {
    private List<Product> productList;
    public File file = new File("Products.txt");

    public ProductManager() {
        this.productList = new ArrayList<>();
    }

    public ProductManager(List<Product> productList) {
        this.productList = productList;
    }

    public List<Product> getProductList() {
        return productList;
    }

    public int addProduct(Product p) {
        this.productList.add(p);
        return count();
    }

    public int count() {
        return this.productList.size();
    }

    public Product getProduct(int index) {
        if (index < 0 || index >= count())
            return null;
        return this.productList.get(index);
    }

    public boolean removeProduct(int id) {
        int index = -1;
        for (int i = 0, n = count(); i < n; i++) {
            if (this.productList.get(i).getProductId() == id) {
                index = i;
                break;
            }
        }
        if (index != -1) {
            this.productList.remove(index);
            return true;
        }
        return false;
    }
}