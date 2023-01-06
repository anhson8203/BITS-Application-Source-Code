package com.pms.io;

import com.pms.entity.Product;

import java.io.*;
import java.util.*;
import java.util.logging.*;

public class ProductIO {
    public boolean save(List<Product> list) {
        PrintStream ps = null;
        try {
            ps = new PrintStream(new FileOutputStream("Products.txt"));
            for (Product p : list) {
                ps.println(p.getProductId() + "," + p.getProductName() + "," + p.getProductCategory() + "," + p.getPrice());
            }
        } catch (FileNotFoundException ex) {
            Logger.getLogger(ProductIO.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            ps.close();
        }
        return false;
    }

    public List<Product> load() {
        List<Product> list = new ArrayList<>();
        File file = new File("Products.txt");
        if (file.exists()) {
            try {
                String line;
                BufferedReader reader = new BufferedReader(new FileReader(file));
                while ((line = reader.readLine()) != null) {
                    String[] attributes = line.split(",");
                    int id = Integer.parseInt(attributes[0]);
                    float price = Float.parseFloat(attributes[3]);
                    Product p = new Product(id, attributes[1], attributes[2], price);
                    list.add(p);
                }
            } catch (FileNotFoundException ex) {
                Logger.getLogger(ProductIO.class.getName()).log(Level.SEVERE, null, ex);
            } catch (IOException ex) {
                Logger.getLogger(ProductIO.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        return list;
    }
}