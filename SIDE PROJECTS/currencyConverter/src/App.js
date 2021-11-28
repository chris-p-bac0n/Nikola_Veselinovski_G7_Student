import React, { useEffect, useState } from "react";
import axios from 'axios';
import Currency from './Currency';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import convertImg from "./img/arrow-left-right.svg";

let conversionData;

function App() {

  const [currencyOptions, setCurrencyOptions] = useState([]);
  const [fromCurrency, setFromCurrency] = useState("USD");
  const [toCurrency, setToCurrency] = useState("EUR");
  const [conversionCurrency, setConversionCurrency] = useState("EUR");
  const [conversionRate, setConversionRate] = useState();

  const apiUrl = `https://freecurrencyapi.net/api/v2/latest?apikey=d80323e0-4eec-11ec-8fc7-8b11d8923846&base_currency=${fromCurrency}`

  const sendGetRequest = async () => {
    try {
      await axios.get(apiUrl)
        .then((resp) => {
          console.log(resp.data.data);
          conversionData = resp.data.data;
          setCurrencyOptions([])
          setCurrencyOptions([resp.data.query.base_currency, ...Object.keys(conversionData)]);
          setConversionRate(conversionData[toCurrency]);
          setConversionCurrency(toCurrency)
        })
    } catch (err) {
      console.error(err);
    }
  };

  const convertCurrency = (e) => {
    e.preventDefault()
    sendGetRequest()
  }

  const switchCurrency = (e) => {
    e.preventDefault()

    let a = fromCurrency;
    let b = toCurrency;
    let temp;
    temp = a;
    a = b;
    b = temp;

    setFromCurrency(a);
    setToCurrency(b);
    sendGetRequest()
  }

  useEffect(() => { sendGetRequest() }, [])

  return (
    <>
      <div id="currencyConverterDiv" className="d-flex flex-wrap">
        <Currency
          currency={currencyOptions}
          selectedCurrency={fromCurrency}
          onChangeCurrency={e => setFromCurrency(e.target.value)}
        />
        <button onClick={e => { switchCurrency(e) }}
          type="button"
          className="btn btn-default">
          <img alt="switch currencies" src={convertImg} width="20" />
        </button>
        <Currency
          currency={currencyOptions}
          selectedCurrency={toCurrency}
          onChangeCurrency={e => setToCurrency(e.target.value)}
        />
        <button onClick={e => { convertCurrency(e) }}
          type="button" className="mx-4 btn btn-primary btn-sm">
          Convert
        </button>
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
