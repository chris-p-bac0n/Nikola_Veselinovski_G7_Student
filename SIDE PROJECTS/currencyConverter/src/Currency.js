import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';

export default function Currency(props) {

    const {
        currency,
        selectedCurrency,
        onChangeCurrency
    } = props

    return (
        <div>
            <select value={selectedCurrency} className="mr-5 my-3 form-select" onChange={onChangeCurrency}>
                {currency.map((currencyOption, index) => (
                    <option key={index} value={currencyOption}>{currencyOption}</option>
                ))}
            </select>
        </div>
    )
}