import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';

export default function Currency(props) {

    const {
        currency,
        defaultSelect,
        onChangeCurrency
    } = props

    return (
        <div>
            <select value={defaultSelect} className="form-select" onChange={onChangeCurrency}>
                {currency.map(currencyOption => (
                    <option key={currencyOption} value={currencyOption}>{currencyOption}</option>
                ))}
            </select>
        </div>
    )
}