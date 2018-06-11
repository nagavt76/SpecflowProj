package com.ing.spendanalyzer.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@Entity
@Table(name = "A1StockData")
/*@JsonIgnoreProperties(value = { "createdAt", "updatedAt" }, allowGetters = true)*/
public class StockData {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + id;
		long temp;
		temp = Double.doubleToLongBits(stock_price);
		result = prime * result + (int) (temp ^ (temp >>> 32));
		result = prime * result + ((stockname == null) ? 0 : stockname.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		StockData other = (StockData) obj;
		if (id != other.id)
			return false;
		if (Double.doubleToLongBits(stock_price) != Double.doubleToLongBits(other.stock_price))
			return false;
		if (stockname == null) {
			if (other.stockname != null)
				return false;
		} else if (!stockname.equals(other.stockname))
			return false;
		return true;
	}

	@Column(name = "stock_name")
	private String stockname;

	@Column(name = "stock_price")
	private double stock_price;

	public void setId(int id) {
		this.id = id;
	}

/*	@Column(name = "quantity")
	private int quantity;*/

	public int getId() {
		return id;
	}

	public String getStockname() {
		return stockname;
	}

	public void setStockname(String stockname) {
		this.stockname = stockname;
	}

	public double getStock_price() {
		return stock_price;
	}

	public void setStock_price(double stock_price) {
		this.stock_price = stock_price;
	}

	/*public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}*/

	/*public void StockData(int id, String stockname, double stock_price) {

		this.id = id;
		this.stockname = stockname;
		this.stock_price = stock_price;

	}*/

}
