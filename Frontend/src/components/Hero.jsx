import React from 'react';

const Hero = () => {
  return (
    <section className="hero-section container">
      <div className="hero-content">
        <h1>Software para <span>profesionales</span> y empresas.</h1>
        <p>Administrá tus clientes, agenda, archivos, turnos, sesiones, videollamadas, pagos y mucho más de una manera simple y eficaz.</p>
        <div className="hero-actions">
          <button className="btn btn-primary">Probalo Gratis</button>
          <button className="btn btn-outline">Ver Demostración</button>
        </div>
      </div>
      <div className="hero-image">
        {/* Placeholder para una imagen o mockup del software */}
        <div className="mockup-placeholder">
          <div className="mockup-header">
            <span></span><span></span><span></span>
          </div>
          <div className="mockup-body">
            <div className="mockup-sidebar"></div>
            <div className="mockup-content">
              <div className="mockup-card"></div>
              <div className="mockup-card"></div>
              <div className="mockup-card"></div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Hero;
