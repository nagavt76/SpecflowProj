package com.ing.spendanalyzer.service;

import java.util.List;

import org.springframework.stereotype.Component;

import com.ing.spendanalyzer.model.SpendAnalyzer;
@Component
public interface SpendAnalyzerService {

	List<SpendAnalyzer> getAllTransactions(Long customerId);

	SpendAnalyzer createTransactions(SpendAnalyzer spendAnalyzer);

}