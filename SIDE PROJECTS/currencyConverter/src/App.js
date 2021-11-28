import React, { useEffect, useState } from "react";
import axios from 'axios';
import Currency from './Currency';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import convertImg from "./img/arrow-left-right.svg";

let baseFromCurrency = "USD";
let baseToCurrency = "EUR";
let conversionRate;
let conversionCurrency;
let onChangeCurrency;
const apiUrl = `https://freecurrencyapi.net/api/v2/latest?apikey=d80323e0-4eec-11ec-8fc7-8b11d8923846&base_currency=${baseFromCurrency}`

function App() {

  const [currencyOptions, setCurrencyOptions] = useState([]);
  const [fromCurrency, setFromCurrency] = useState();
  const [toCurrency, setToCurrency] = useState();

  useEffect(() => {

    axios({
      method: "GET",
      url: apiUrl
    })
      .then((response) => {
        console.log(response.data);
        // const firstCurrency = Object.keys(response.data.data)[0];
        setCurrencyOptions([response.data.query.base_currency, ...Object.keys(response.data.data)]);
        // setFromCurrency(response.data.query.base_currency);
        // setToCurrency(firstCurrency)
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
          defaultSelect={baseFromCurrency}
          onChangeCurrency={e=>setFromCurrency(e.target.value)}
          baseFromCurrency = {fromCurrency}
        />
        <button className="btn btn-default">
          <img alt="switch currencies" src={convertImg} width="20" />
        </button>
        <Currency
          currency={currencyOptions}
          defaultSelect={baseToCurrency}
          onChangeCurrency={e=>setToCurrency(e.target.value)}
          baseToCurrency = {toCurrency}
          // conversionCurrency={e => (e.target.value)}
        />
        <button type="button" className="mx-4 btn btn-primary btn-sm">Convert</button>
        <div className="d-flex justify-content-center align-items-center">
          <span className="font-weight-bold">=</span>
          <span className="pl-3 font-weight-bold">{conversionRate}</span>
          <span className="pl-3 font-weight-bold">{conversionCurrency}</span>
        </div>
      </div>
    </>
  );
}

export default App;
