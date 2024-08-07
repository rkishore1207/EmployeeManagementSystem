/* eslint-disable @typescript-eslint/no-explicit-any */

interface LogoProps{
    logoHeight?:any,
    logoWidth?:any
}

const Logo = ({logoWidth = '80%', logoHeight = '100%'}:LogoProps) => {
    return (
        <img src="images/logo.png" width={logoWidth} height={logoHeight} alt="Logo"/>
    );
};

export default Logo;