import React from 'react';
import './footer-style.css';

const Footer = () => {
  return (
    <div className="footer-fixed">
      {[...Array(10)].map((_, index) => (
        <button className="footer-item" key={index}>
          {index + 1}
        </button>
      ))}
    </div>
  );
};

export default Footer;