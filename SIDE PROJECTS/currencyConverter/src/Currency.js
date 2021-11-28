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
            <select value={selectedCurrency} className="form-select" onChange={onChangeCurrency}>
                {currency.map(currencyOption => (
                    <option key={currencyOption} value={currencyOption}>{currencyOption}</option>
                ))}
            </select>
        </div>
    )
}