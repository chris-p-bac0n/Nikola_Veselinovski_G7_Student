import React, { useEffect, useState } from "react";
import axios from 'axios';
import Currency from './Currency';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import convertImg from "./img/arrow-left-right.svg";

let baseCurrency = "USD"
const apiUrl = `https://freecurrencyapi.net/api/v2/latest?apikey=d80323e0-4eec-11ec-8fc7-8b11d8923846&base_currency=${baseCurrency}`

function App() {

  const [currencyOptions, setCurrencyOptions] = useState([])
  const [setFromCurrency, setToCurrency] = useState()

  useEffect(() => {

    axios({
      method: "GET",
      url: apiUrl
    })
      .then((response) => {
        console.log(response);
        const firstCurrency = Object.keys(response.data.data)[0];
        setCurrencyOptions([response.data.query.base_currency, ...Object.keys(response.data.data)]);
        setFromCurrency(response.data.query.base_currency);
        setToCurrency(firstCurrency)
      })
      .catch((error) => {
        console.log(error);
      })
  }, [])

  return (
    <>
      <div id="currencyConverterDiv" className="d-flex flex-wrap">
        <Currency
          currency={currencyOptions}
          selectedCurrency={setFromCurrency}
        />
        <button className="btn btn-default">
          <img alt="switch currencies" src={convertImg} width="20" />
        </button>
        <Currency
          currency={currencyOptions}
          selectedCurrency={setToCurrency}
        />
        <button type="button" className="mx-4 btn btn-primary btn-sm">Convert</button>
        <div className="d-flex justify-content-center align-items-center">
          <span className="font-weight-bold">=</span>
          <span className="pl-3 font-weight-bold" id="conversionResult">test</span>
          <span className="pl-3 font-weight-bold" id="conversionCurrency">test</span>
        </div>
      </div>
    </>
  );
}

export default App;
