import React, { useEffect, useState } from "react";
import axios from 'axios';
import Currency from './Currency';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import convertImg from "./img/arrow-left-right.svg";

let baseFromCurrency = "USD";
// let baseToCurrency = "EUR";
// let conversionRate;
// let conversionCurrency;
// let onChangeCurrency;
let conversionData;

const apiUrl = `https://freecurrencyapi.net/api/v2/latest?apikey=d80323e0-4eec-11ec-8fc7-8b11d8923846&base_currency=${baseFromCurrency}`

function App() {

  const [currencyOptions, setCurrencyOptions] = useState([]);
  const [fromCurrency, setFromCurrency] = useState();
  const [toCurrency, setToCurrency] = useState("EUR");
  const [conversionCurrency, setConversionCurrency] = useState("EUR");
  const [conversionRate, setConversionRate] = useState();

  useEffect(() => {

    axios({
      method: "GET",
      url: apiUrl
    })
      .then((response) => {
        conversionData = response.data.data;

        setCurrencyOptions([response.data.query.base_currency, ...Object.keys(conversionData)]);

        console.log("SET");
        setConversionRate(conversionData[toCurrency]);

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
          selectedCurrency={fromCurrency}
          baseFromCurrency={fromCurrency}
          onChangeCurrency={e => setFromCurrency(e.target.value)}
        />
        <button className="btn btn-default">
          <img alt="switch currencies" src={convertImg} width="20" />
        </button>
        <Currency
          currency={currencyOptions}
          selectedCurrency={toCurrency}
          onChangeCurrency={e => {
            console.log("TO");
            setToCurrency(e.target.value);
            setConversionCurrency(e.target.value);
            console.log("SETRATE");
            setConversionRate(conversionData[toCurrency]);
            // setConversionRate(e.target.value);
          }}
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
