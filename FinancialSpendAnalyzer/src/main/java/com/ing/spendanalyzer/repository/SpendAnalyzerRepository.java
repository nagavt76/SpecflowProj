package com.ing.spendanalyzer.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.ing.spendanalyzer.model.SpendAnalyzer;

/**
 * Created by rajeevkumarsingh on 27/06/17.
 */

@Repository
public interface SpendAnalyzerRepository extends JpaRepository<SpendAnalyzer, Long> {

}
