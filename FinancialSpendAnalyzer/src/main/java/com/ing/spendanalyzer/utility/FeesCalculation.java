package com.ing.spendanalyzer.utility;

import java.sql.Timestamp;
import java.util.Date;

import com.ing.spendanalyzer.model.SpendAnalyzer;

public class FeesCalculation 
{
	
	
	
	/*public static Double calculateFinalPrice(Double stockPrice, int numberOfStocks,SpendAnalyzer stockDetails)
	{
		Double finalAmount;
		Double brokerageCharges;
		brokerageCharges = numberOfStocks * 0.1;

		stockDetails.setStock_date(new Timestamp(new Date().getTime()));

		//base case - no of stocks < 500 - brokerage - .10%
		if(numberOfStocks < 500)
		{
			finalAmount = stockPrice * numberOfStocks + brokerageCharges;
			stockDetails.setFees(finalAmount * 0.1);
			stockDetails.setFinal_price(finalAmount);
			return finalAmount;
		}
		//Other use case - no of stocks >= 500 
		else
		{
			brokerageCharges = numberOfStocks * 0.1;
			finalAmount = stockPrice * 499 + brokerageCharges;

			int afterLeftStocks = numberOfStocks - 499;

			brokerageCharges = afterLeftStocks * 0.15;
			finalAmount += stockPrice * afterLeftStocks + brokerageCharges;
			stockDetails.setFees(finalAmount * 0.15);
			stockDetails.setFinal_price(finalAmount);
			return finalAmount;
		}
	*/}
	
