import logo from './logo.svg';
import './App.css';
import { GoogleOAuthProvider, GoogleLogin } from '@react-oauth/google';

function App() {
  var tokenName = "healthTrackerWebAppToken";
  const id = process.env.GOOGLE_CLIENT_ID;
  console.log(id)
  let toReturn;

  if (localStorage.getItem(tokenName) != null) {
    toReturn = 
     (
      <>
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <p>
            Edit <code>src/App.js</code> and save to reload.
          </p>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React
          </a>
        </header>
      </div>
      </>
    );
  }

  else {
    toReturn = (
      <GoogleLogin
      clientId='323751452219-jdd3o4324pffq2q6e3mul6f3cbs14gcn.apps.googleusercontent.com'
        onSuccess={(credentialResponse) => {
          console.log(credentialResponse);
          localStorage.setItem(tokenName, credentialResponse.credential)
          window.location.reload();
        }}
        onError={() => {
          console.log('Login Failed');
        }}
      />
    );
  }
  return (
    <GoogleOAuthProvider clientId='323751452219-jdd3o4324pffq2q6e3mul6f3cbs14gcn.apps.googleusercontent.com'>
      {toReturn}
    </GoogleOAuthProvider>);
}

export default App;
