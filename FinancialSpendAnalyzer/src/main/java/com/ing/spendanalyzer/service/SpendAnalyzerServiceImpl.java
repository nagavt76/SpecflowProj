package com.ing.spendanalyzer.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.ing.spendanalyzer.model.SpendAnalyzer;
import com.ing.spendanalyzer.repository.SpendAnalyzerRepository;

@Service
public class SpendAnalyzerServiceImpl implements SpendAnalyzerService {

	@Autowired
	SpendAnalyzerRepository spendAnalyzerRepository;

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.example.easynotes.service.StockService2#getAllOrders()
	 */
	@Override
	public List<SpendAnalyzer> getAllTransactions(Long customerId) {
		
		List<SpendAnalyzer> spendAnalyzerList = new ArrayList<SpendAnalyzer>();
		List<SpendAnalyzer> spendAnalyzerTransList = new ArrayList<SpendAnalyzer>();
		spendAnalyzerList = spendAnalyzerRepository.findAll();
		for(SpendAnalyzer spendAnalyzer :spendAnalyzerList){
			if(((Long)spendAnalyzer.getCustomerId()).equals(customerId)){
				spendAnalyzerTransList.add(spendAnalyzer);
			}
		}
		
		return spendAnalyzerTransList;
	}

	@Override
	public SpendAnalyzer createTransactions(SpendAnalyzer spendAnalyzer) {
		return spendAnalyzerRepository.save(spendAnalyzer);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.example.easynotes.service.StockService2#createOrder(com.example.
	 * easynotes.model.StockDetails)
	 */
	/*@Override
	public SpendAnalyzer createOrder(@Valid @RequestBody SpendAnalyzer stockDetails) {

		SpendAnalyzer stockDetailsUpdated;
		 if(stockDetails !=null){ 
		double totPrice = FeesCalculation.calculateTotalPrice(stockDetails.getStock_price(),
				stockDetails.getQuantity());
		stockDetails.setTotal_price(totPrice);
		stockDetails.setFinal_price(
				FeesCalculation.calculateFinalPrice(stockDetails.getStock_price(), stockDetails.getQuantity(),stockDetails));
		return noteRepository.save(stockDetails);
	}*/
}
