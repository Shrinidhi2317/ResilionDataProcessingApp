Data Processing with Singleton Design Pattern
Overview
This project implements a thread-safe, singleton-based data processing system designed to batch process input objects efficiently using GPU-like simulation. It is suitable for scenarios involving multiple worker threads submitting data concurrently, requiring optimized batch processing without re-entrant GPU calls.

Features
Thread-safe queuing of data objects from multiple worker threads

Batch processing of up to 4 objects for maximum GPU utilization

Singleton pattern for single GPU resource handling

Simulation of GPU processing delay (1 second per batch)

Processing APIs that accept a single data object and return a corresponding result

Architecture
DataObject: Represents input data

Result: Represents processed output

DataProcessor: Singleton class responsible for batching and simulated GPU processing

Usage
Instantiate DataObject instances and pass each to DataProcessor.Instance.ProcessSingle(). It will internally batch and process in the background, returning a single Result for each call.

Installation
Clone the repository

Build using your preferred .NET development environment

Run the example console application or write your tests

Testing
Unit tests are included to verify behavior. Run them via your IDE's test explorer or using dotnet
