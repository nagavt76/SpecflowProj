package com.ing.spendanalyzer.controller;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.ing.spendanalyzer.exception.BadRequestException;
import com.ing.spendanalyzer.model.SpendAnalyzer;
import com.ing.spendanalyzer.service.SpendAnalyzerService;
import com.ing.spendanalyzer.utility.FeesCalculation;

@RestController
@RequestMapping("/api")
@CrossOrigin("*")
public class SpendAnalyzerController {

	@Autowired
	SpendAnalyzerService spendAnalyzerService;

	@GetMapping("/transactions/{customerId}")
	/* @CrossOrigin(origins = "*", allowedHeaders = "*") */
	public List<SpendAnalyzer> getAllTransactions(@PathVariable(value = "customerId") Long customerId) {
		return spendAnalyzerService.getAllTransactions(customerId);
	}

	@PostMapping("/transactions")
	public SpendAnalyzer createTransaction(@Valid @RequestBody SpendAnalyzer spendAnalyzer) {

		// SpendAnalyzer spendAnalyzer;
		if (spendAnalyzer != null) {

			return spendAnalyzerService.createTransactions(spendAnalyzer);
		} else {
			throw new BadRequestException("stockDetails", "stockDetails", spendAnalyzer);
		}

	}
	/*
	 * 
	 * @Autowired StockService stockService;
	 * 
	 * @GetMapping("/orders")
	 * 
	 * @CrossOrigin(origins = "*", allowedHeaders = "*") public
	 * List<StockDetails> getAllOrders() { return stockService.getAllOrders(); }
	 * 
	 * @GetMapping("/stocks")
	 * 
	 * @CrossOrigin(origins = "*", allowedHeaders = "*") public List<StockData>
	 * getAllStockes() {
	 * 
	 * List<StockData> stockDataList= new ArrayList<StockData>(); StockData
	 * stockData = new StockData(); stockData.setId(1);
	 * stockData.setStock_price(1300); stockData.setStockname("HCL");
	 * stockDataList.add(stockData);
	 * 
	 * StockData stockData1 = new StockData();
	 * 
	 * stockData1.setId(2); stockData1.setStock_price(1200);
	 * stockData1.setStockname("INFOSYS"); stockDataList.add(stockData1);
	 * 
	 * StockData stockData3 = new StockData(); stockData3.setId(3);
	 * stockData3.setStock_price(1000); stockData3.setStockname("DELL");
	 * stockDataList.add(stockData3);
	 * 
	 * StockData stockData4 = new StockData(); stockData4.setId(4);
	 * stockData4.setStock_price(1400); stockData4.setStockname("TECHM");
	 * stockDataList.add(stockData4); return stockDataList; }
	 * 
	 * @PostMapping("/orders") public StockDetails
	 * createOrder(@Valid @RequestBody StockDetails stockDetails) {
	 * 
	 * StockDetails stockDetailsUpdated; if(stockDetails != null){ double
	 * totPrice =
	 * FeesCalculation.calculateTotalPrice(stockDetails.getStock_price(),
	 * stockDetails.getQuantity()); stockDetails.setTotal_price(totPrice);
	 * stockDetails.setFinal_price(
	 * FeesCalculation.calculateFinalPrice(stockDetails.getStock_price(),
	 * stockDetails.getQuantity(), stockDetails)); return
	 * stockService.createOrder(stockDetails); } else { throw new
	 * BadRequestException("stockDetails", "stockDetails", stockDetails); }
	 * 
	 * }
	 * 
	 * @GetMapping("/notes/{id}") public Note getNoteById(@PathVariable(value =
	 * "id") Long noteId) { return noteRepository.findById(noteId)
	 * .orElseThrow(() -> new ResourceNotFoundException("Note", "id", noteId));
	 * }
	 * 
	 * @PutMapping("/notes/{id}") public Note updateNote(@PathVariable(value =
	 * "id") Long noteId,
	 * 
	 * @Valid @RequestBody Note noteDetails) {
	 * 
	 * Note note = noteRepository.findById(noteId) .orElseThrow(() -> new
	 * ResourceNotFoundException("Note", "id", noteId));
	 * 
	 * note.setTitle(noteDetails.getTitle());
	 * note.setContent(noteDetails.getContent());
	 * 
	 * Note updatedNote = noteRepository.save(note); return updatedNote; }
	 * 
	 * @DeleteMapping("/notes/{id}") public ResponseEntity<?>
	 * deleteNote(@PathVariable(value = "id") Long noteId) { Note note =
	 * noteRepository.findById(noteId) .orElseThrow(() -> new
	 * ResourceNotFoundException("Note", "id", noteId));
	 * 
	 * noteRepository.delete(note);
	 * 
	 * return ResponseEntity.ok().build(); }
	 */}
