import React, { useState } from "react";
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import logo from './img/plus.png';

function App() {
  const [input, setInput] = useState("");
  const [calculatedSum, setCalculatedSum] = useState("Get your result here!");

  const apiUrl = `https://localhost:44393/api/text-calculator`;

  const sendPostRequest = async () => {
    try {
      await axios.post(apiUrl, { input: input })
        .then((resp) => {
          setCalculatedSum(Object.values(resp.data));
        })
    } catch (err) {
      console.error(err);
    }
  };

  const calculateSum = (e) => {
    e.preventDefault();
    sendPostRequest();
  }

  return (
    <>
      <div id="textCalculatorDiv" className="d-flex flex-column flex-wrap justify-content-center">
        <div className="d-flex justify-content-center">
          <img className="plusLogo" src={logo} alt="Logo" />
        </div>
        <h3 className="text-center">Text Calculator</h3>
        <div className="d-flex justify-content-center">
          <input className='form-control w-75 text-center'
            type="text"
            value={input}
            onChange={(e) => setInput(e.target.value)}
            placeholder='Enter numbers here!'
          />
        </div>
        <div className="d-flex justify-content-center">
          <button onClick={e => { calculateSum(e) }}
            type="button"
            className="mx-4 my-3 btn btn-primary btn-sm shadow-none">
            Calculate
          </button>
        </div>
        <div className="my-3 d-flex flex-column justify-content-center align-items-center">
          <span className="font-weight-bold text-center">{calculatedSum}</span>
        </div>
        <hr></hr>
        <div className="d-flex justify-content-center">
          <span className="text-justify mr-3">
            <ul>
              <li>Enter numbers to get their sum!</li>
              <li>Separate the numbers with commas ","</li>
              <li>To use decimals use a full stop "."</li>
              <li>Negative numbers are not allowed</li>
            </ul>
          </span>
        </div>
      </div>
    </>
  );
}
export default App;
